using OCMS.Common.CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.DTO_s.ComplaintDto_s
{
    public class UpdateCompStatusDTO
    {
        public Guid ComplaintId { get; set; }
        public ComplaintStatus Status { get; set; }
    }
}