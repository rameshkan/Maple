using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace MapleCore.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [NotMapped]
        public string StatusCode {get;set;}

        [NotMapped]
        public string StatusMessage { get; set; }

    }
}
