using SQLite;
using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models.red
{
    public partial class WoUsers
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public virtual WoUsers User { get; set; }

        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundImageStatus { get; set; }
        public int RelationshipId { get; set; }
        public string Address { get; set; }
        public string Working { get; set; }
        public string WorkingLink { get; set; }
        public string About { get; set; }
        public string School { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public int CountryId { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
        public string Vk { get; set; }
        public string Instagram { get; set; }
        public string Language { get; set; }
        public string EmailCode { get; set; }
        public string Src { get; set; }
        public string IpAddress { get; set; }
        public string FollowPrivacy { get; set; }
        public string FriendPrivacy { get; set; }
        public string PostPrivacy { get; set; }
        public string MessagePrivacy { get; set; }
        public string ConfirmFollowers { get; set; }
        public string ShowActivitiesPrivacy { get; set; }
        public string BirthPrivacy { get; set; }
        public string VisitPrivacy { get; set; }
        public string Verified { get; set; }
        public int Lastseen { get; set; }
        public string Showlastseen { get; set; }
        public string EmailNotification { get; set; }
        public string ELiked { get; set; }
        public string EWondered { get; set; }
        public string EShared { get; set; }
        public string EFollowed { get; set; }
        public string ECommented { get; set; }
        public string EVisited { get; set; }
        public string ELikedPage { get; set; }
        public string EMentioned { get; set; }
        public string EJoinedGroup { get; set; }
        public string EAccepted { get; set; }
        public string EProfileWallPost { get; set; }
        public string ESentmeMsg { get; set; }
        public string ELastNotif { get; set; }
        public string NotificationSettings { get; set; }
        public string Status { get; set; }
        public string Active { get; set; }
        public string Admin { get; set; }
        public string Type { get; set; }
        public string Registered { get; set; }
        public string StartUp { get; set; }
        public string StartUpInfo { get; set; }
        public string StartupFollow { get; set; }
        public string StartupImage { get; set; }
        public int LastEmailSent { get; set; }
        public string PhoneNumber { get; set; }
        public int SmsCode { get; set; }
        public string IsPro { get; set; }
        public int ProTime { get; set; }
        public string ProType { get; set; }
        public int Joined { get; set; }
        public string CssFile { get; set; }
        public string Timezone { get; set; }
        public int Referrer { get; set; }
        public string Balance { get; set; }
        public string PaypalEmail { get; set; }
        public string NotificationsSound { get; set; }
        public string OrderPostsBy { get; set; }
        public string SocialLogin { get; set; }
        public string AndroidMDeviceId { get; set; }
        public string IosMDeviceId { get; set; }
        public string AndroidNDeviceId { get; set; }
        public string IosNDeviceId { get; set; }
        public string WebDeviceId { get; set; }
        public string Wallet { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string LastLocationUpdate { get; set; }
        public int ShareMyLocation { get; set; }
        public int LastDataUpdate { get; set; }
        public string Details { get; set; }
        public string SidebarData { get; set; }
        public int LastAvatarMod { get; set; }
        public int LastCoverMod { get; set; }
        public float Points { get; set; }
        public int DailyPoints { get; set; }
        public string PointDayExpire { get; set; }
        public int LastFollowId { get; set; }
        public int ShareMyData { get; set; }
        public string LastLoginData { get; set; }
        public int TwoFactor { get; set; }
        public string NewEmail { get; set; }
        public int TwoFactorVerified { get; set; }
        public string NewPhone { get; set; }
        public string InfoFile { get; set; }
    }
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contraseña { get; set; }
    }
}
