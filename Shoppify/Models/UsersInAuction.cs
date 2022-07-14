using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppify.Models
{
    public class UsersInAuction
    {
        //FK
        public long AuctionId { get; set; }
        //FK
        public long UserId { get; set; }
    }
}
