using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Common.CommonClasses.Enums
{
    public enum ComplaintStatusReq
    {
        Approved = 0,
        Pending = 1,
        InProgress = 2,
        Resolved = 3,
        Rejected = 4,
        AllComplaints
    }
}