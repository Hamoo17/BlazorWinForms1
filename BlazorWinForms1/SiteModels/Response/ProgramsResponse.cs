using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWinForms1.SiteModels.Response
{
    public class ProgramsResponse
    {
        public int Id { get; set; }
        public string ProgramType { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string ShortcutName { get; set; }
    }
}
