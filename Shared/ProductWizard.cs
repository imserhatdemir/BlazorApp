using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class ProductWizard
    {
        [JsonIgnore]
        public Product? Product { get; set; }
        public int ProdId { get; set; }
         public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public string WizardName { get; set; } = string.Empty;
        public string Wizard { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
