using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnonymForum2.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int Fktopic { get; set; } = 0;
        public string Title { get; set; } = null!;
        public string Contents { get; set; } = null!;
        public DateTime TimePosted { get; set; }
    }
}
