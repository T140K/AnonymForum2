using System;
using System.Collections.Generic;

namespace AnonymForumAPI.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
    }
}
