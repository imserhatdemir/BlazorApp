using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class MissionVision
    {
        public int Id { get; set; }
        public string TitleMission { get; set; } = string.Empty;
        public string DetailMission { get; set; } = string.Empty;
        public string TitleVision { get; set; } = string.Empty;
        public string DetailVision { get; set; } = string.Empty;
        public string ImageUrlMission { get; set; } = string.Empty;
        public string ImageUrlVision { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
