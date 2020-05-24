using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models.red
{
    public partial class WoGroups
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GroupName { get; set; }
        public string GroupTitle { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public string About { get; set; }
        public int Category { get; set; }
        public string Privacy { get; set; }
        public string JoinPrivacy { get; set; }
        public string Active { get; set; }
        public string Registered { get; set; }
    }
}
