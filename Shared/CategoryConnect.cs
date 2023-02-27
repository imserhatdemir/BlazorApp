using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class CategoryConnect
    {
        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public MainCategory? MainCategory { get; set; }
        public int MainCategoryId { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
