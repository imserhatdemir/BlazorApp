using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class ContactAddress
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
    }
}
