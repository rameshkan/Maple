﻿using MapleCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleWebApi
{
    public class BaseController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        protected readonly IRepository _repository;

        protected BaseController(IRepository repository)
        {
            _repository = repository;
        }

        protected BaseController(IRepository repository, IConfiguration configuration)
        {
            _configuration = configuration;
            _repository = repository;
        }
    }
}
