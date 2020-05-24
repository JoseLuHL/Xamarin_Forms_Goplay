using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models.red
{
    public partial class WoGroupMembers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int Time { get; set; }
        public string Active { get; set; }
        public virtual WoGroups Grupo { get; set; }
        public virtual WoUsers  User { get; set; }
    }
}
