using System;
using System.Collections.Generic;

namespace service_repo_api.Domain
{
    public partial class Services
    {
        public Services()
        {
            Comments = new HashSet<Comments>();
            ErrorLogs = new HashSet<ErrorLogs>();
        }

        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
        public string Platform { get; set; }
        public string Protocol { get; set; }
        public bool? IsActive { get; set; }
        public string TeamResponsible { get; set; }
        public string SecurityType { get; set; }
        public string SecurityNotes { get; set; }
        public string ServerEnvironment { get; set; }
        public string EndpointAddress { get; set; }
        public string Documentation { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<ErrorLogs> ErrorLogs { get; set; }
    }
}
