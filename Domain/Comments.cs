using System;
using System.Collections.Generic;

namespace service_repo_api.Domain
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public string CommentDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? FkServiceId { get; set; }

        public virtual Services FkService { get; set; }
    }
}
