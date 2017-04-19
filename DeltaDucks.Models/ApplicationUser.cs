using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeltaDucks.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Score { get; set; }

        public byte[] UserPhoto { get; set; }

        public virtual ICollection<Landmark> VisitedLandmarks { get; set; }
        
        public virtual ICollection<UserNotification> Notifications { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public ApplicationUser()
        {
            this.Comments = new HashSet<Comment>();
            this.VisitedLandmarks = new HashSet<Landmark>();
            this.Score = 0;
            this.Notifications= new HashSet<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            this.Notifications.Add(new UserNotification(this,notification));
        }
    }
}