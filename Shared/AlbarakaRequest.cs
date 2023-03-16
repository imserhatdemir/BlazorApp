using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class AlbarakaRequest
    {
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CardCVV { get; set; }
        public string MERCHANT_NO { get; set; }
        public string TERMINAL_NO { get; set; }
        public string EPOS_NO { get; set; }
        public string ENCKEY { get; set; } = "10,10,10,10,10,10,10,10";
    }
}
