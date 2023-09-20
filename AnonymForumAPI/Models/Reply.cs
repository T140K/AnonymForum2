using System;
using System.Collections.Generic;

namespace AnonymForumAPI.Models
{
    public partial class Reply
    {
        public int Id { get; set; }
        public int Fkpost { get; set; }
        public string Contents { get; set; } = null!;
        public DateTime ReplyDate { get; set; }

        public virtual Post FkpostNavigation { get; set; } = null!;
    }
}
