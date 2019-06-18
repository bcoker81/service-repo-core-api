using System;
using System.Collections.Generic;

namespace service_repo_api.Domain
{
    public partial class ErrorLogs
    {
        public int ErrorId { get; set; }
        public int FkServiceId { get; set; }
        public string Arguments { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }

        public virtual Services FkService { get; set; }
    }
}
