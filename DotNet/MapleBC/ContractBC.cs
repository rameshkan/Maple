using MapleCore.Interfaces;
using MapleDTO;
using System;
using System.Linq;
using System.Collections.Generic;
using MapleCTO;

namespace MapleBC
{
    public class ContractBC
    {
        private readonly IRepository _repository;

        public ContractBC(IRepository repository )
        {
            _repository = repository;
        }

        public Contract CreateContract(CustomerCTO customerInfo)
        {
            return SaveContract(customerInfo, "I", Guid.Empty);
        }

        public Contract UpdateContract(Contract contract)
        {
            var customer = new CustomerCTO()
            {
                CustomerAddress = contract.CustomerAddress,
                CustomerCountry = contract.CustomerCountry,
                CustomerDOB = contract.CustomerDOB,
                CustomerName = contract.CustomerName,
                CustomerGender = contract.CustomerGender,
                SaleDate = contract.SaleDate
            };
            return SaveContract(customer, "M", contract.Id);
        }

        public void DeleteContract(Guid id)
        {
            var contract = _repository.GetById<Contract>(id);
            if(contract != null)
                _repository.Delete<Contract>(contract, true);
        }

        private Contract SaveContract(CustomerCTO customerInfo, string action, Guid id)
        {
            Contract contract = null;
            if (customerInfo != null)
            {
                contract = FindValidContract(customerInfo);
                if (contract != null)
                {
                    if (action == "I")
                    {
                        contract.Id = new Guid();
                        _repository.Add<Contract>(contract, true);
                    }
                    else
                    {
                        contract.Id = id;
                        _repository.Update<Contract>(contract, true);
                    }
                    contract = FetchContractByGuid(contract.Id);
                    contract.StatusCode = "0";
                    contract.StatusMessage = "Contract Successfully Created";

                }
                else
                {
                    contract = new Contract();
                    contract.StatusCode = "NOPLAN001";
                    contract.StatusMessage = "No matching plans are rate charts for the given input.";
                }

            }
            else
            {
                contract = new Contract();
                contract.StatusCode = "INVALID001";
                contract.StatusMessage = "Invalid customer info. Kindly provide valid input";
            }
            return contract;
        }
        public Contract FetchContractById(Guid contractId)
        {
            return _repository.GetById<Contract>(contractId);
        }
        public List<CustomerCTO> FetchAllContracts(CustomerCTO customer)
        {
            var rateCharts = _repository.GetQuery<RateChart>();
            var plans = _repository.GetQuery<CoveragePlan>();
            var contracts = _repository.GetQuery<Contract>();

            var contractList = from ct in contracts
                               join pl in plans on ct.CoveragePlanId equals pl.Id
                               join rc in rateCharts on ct.RateChartId equals rc.Id
                               where (string.IsNullOrEmpty(customer.CustomerName) || ct.CustomerName == customer.CustomerName)
                               select new CustomerCTO
                               {
                                   CustomerCountry = ct.CustomerCountry,
                                   CustomerAddress = ct.CustomerAddress,
                                   CustomerDOB = ct.CustomerDOB,
                                   CustomerGender = ct.CustomerGender,
                                   CustomerName = ct.CustomerName,
                                   NetPPrice = rc.NetPrice,
                                   CoveragePlanName = pl.PlanName,
                                   SaleDate = ct.SaleDate
                               };

            return contractList.ToList();
        }

        private Contract FetchContractByGuid(Guid id)
        {
            var rateCharts = _repository.GetQuery<RateChart>();
            var plans = _repository.GetQuery<CoveragePlan>();
            var contracts = _repository.GetQuery<Contract>();

            var contractList = from ct in contracts
                               join pl in plans on ct.CoveragePlanId equals pl.Id
                               join rc in rateCharts on ct.RateChartId equals rc.Id
                               where ct.Id == id
                               select new Contract
                               {
                                   CustomerCountry = ct.CustomerCountry,
                                   CustomerAddress = ct.CustomerAddress,
                                   CustomerDOB = ct.CustomerDOB,
                                   CustomerGender = ct.CustomerGender,
                                   CustomerName = ct.CustomerName,
                                   NetPPrice = rc.NetPrice,
                                   PlanName = pl.PlanName,
                                   SaleDate = ct.SaleDate,
                                   Id = ct.Id,
                                   CoveragePlanId = ct.CoveragePlanId,
                                   RateChartId = ct.RateChartId
                               };

            return contractList.FirstOrDefault();
        }


        private Contract FindValidContract(CustomerCTO customer)
        {
            Contract contractInfo = null;

            var planList = _repository.List<CoveragePlan>(a=>
                    a.ElgDateFrom <= customer.SaleDate 
                    && a.ElgDateTo >= customer.SaleDate
                    && (a.ElgCountry == customer.CustomerCountry || a.ElgCountry == "*"));

            CoveragePlan plan = null;
 
            if (planList.Count > 1)
                plan = planList.FirstOrDefault(a => a.ElgCountry != "*");
            else if (planList.Count > 0)
                plan = planList.First();

            if (plan != null)
            {
                var age = customer.SaleDate.Year - customer.CustomerDOB.Year;

                var rateChart = _repository.List<RateChart>(a =>
                        (((age - a.CustomerAge) <= 0 && a.Constraint == "-")
                            || ((age - a.CustomerAge) > 0 && a.Constraint == "+"))
                        && a.CustomerGender == customer.CustomerGender
                        && a.CoveragePlanId == plan.Id
                            ).FirstOrDefault();

                if(rateChart != null)
                {
                    contractInfo = new Contract()
                    {
                        CustomerAddress = customer.CustomerAddress,
                        CustomerCountry = customer.CustomerCountry,
                        CoveragePlanId = plan.Id,
                        CustomerDOB = customer.CustomerDOB,
                        CustomerName = customer.CustomerName,
                        RateChartId = rateChart.Id,
                        CustomerGender = customer.CustomerGender,
                        SaleDate = customer.SaleDate
                    };


                }
            }
            return contractInfo;
        }

    }
}
