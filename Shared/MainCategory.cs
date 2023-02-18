using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Category> Categories { get; set; }
        public bool Visible { get; set; } = true;
        public bool Featured { get; set; } = false;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
