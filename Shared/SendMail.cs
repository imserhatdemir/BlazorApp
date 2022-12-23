using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class SendMail
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
