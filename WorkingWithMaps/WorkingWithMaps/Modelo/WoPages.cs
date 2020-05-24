using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models
{
    public partial class WoPages
    {

        public int PageId { get; set; }
        public int UserId { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        private string avatar;

        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
        private string cover;
        public string Cover { get { return cover ; } set { cover = value; }}
        public int PageCategory { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Vk { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CallActionType { get; set; }
        public string CallActionTypeUrl { get; set; }
        public string BackgroundImage { get; set; }
        public int BackgroundImageStatus { get; set; }
        public string Instgram { get; set; }
        public string Youtube { get; set; }
        public string Verified { get; set; }
        public string Active { get; set; }
        public string Registered { get; set; }
        public string Boosted { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public virtual List<Horario> Horario { get; set; }

    }
}
