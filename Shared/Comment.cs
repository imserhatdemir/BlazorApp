using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public string Details { get; set; } = string.Empty;
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
