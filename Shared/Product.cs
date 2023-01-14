using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string WizardTitle { get; set; } = string.Empty;
        public string WizardDesc { get; set; } = string.Empty;
        public string WizardTitle1 { get; set; } = string.Empty;
        public string WizardDesc1 { get; set; } = string.Empty;
        public string WizardTitle2 { get; set; } = string.Empty;
        public string WizardDesc2 { get; set; } = string.Empty;
        public string WizardTitle3 { get; set; } = string.Empty;
        public string WizardDesc3 { get; set; } = string.Empty;
        public string WizardTitle4 { get; set; } = string.Empty;
        public string WizardDesc4 { get; set; } = string.Empty;
        public List<Image> Images { get; set; } = new List<Image>();
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;

    }
}
