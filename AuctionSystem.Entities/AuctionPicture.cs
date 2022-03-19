using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Entities
{
    public class AuctionPicture : BaseEntity
    {
        public int AuctionId { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
