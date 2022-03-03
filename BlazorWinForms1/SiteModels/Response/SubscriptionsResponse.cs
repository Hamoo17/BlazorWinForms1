using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWinForms1.SiteModels.Response
{
    public class SubscriptionsResponse
    {
        public int Id { get; set; }
        public string SubFrom { get; set; }
        public string InvoiceNum { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public string AgentName { get; set; }
        public int? Discount { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime DeliveryStartingDay { get; set; }
        public string Mode { get; set; }
        public string PlanName { get; set; }
        public string Area { get; set; }
        public string Emarite { get; set; }
    }
}
