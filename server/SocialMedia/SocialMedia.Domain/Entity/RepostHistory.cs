using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entity
{
    public class RepostHistory
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int PostId { get; set; } 
        public DateTime RepostDate { get; set; } = DateTime.UtcNow;
    }
}
