using AuctionSystem.Data;
using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class SharedService
    {
        public int SavePicture(Picture picture)
        {
            DBContext context = new DBContext();
            context.Pictures.Add(picture);
            context.SaveChanges();
            return picture.Id;
        }
    }
}
