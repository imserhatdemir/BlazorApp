﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Icons { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
