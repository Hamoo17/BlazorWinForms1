using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWinForms1.SiteModels.Requests
{
    public class ManagerRequest
    {
        public string InvoiceId { get; set; }
        public string GiftCode { get; set; }
        public string MobileNumber { get; set; }
        public int? DiscountValue { get; set; }
        public int? EmariteID { get; set; }
        public string Plan { get; set; }
        public DateTime? StartDate { get; set; }
        public string SubFrom { get; set; }
        public int? BranchID { get; set; }
        public int? AgentID { get; set; }
        public string Version { get; set; }
        public int? Mode { get; set; }
        public int? InvType { get; set; }
    }
}
