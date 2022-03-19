using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace AuctionSystem.Data
{
    public  class DBContext : DbContext
    {
        public DBContext() : base("name=DBConnectionString")
        {
        }

        public DbSet<Category>Categories{ get; set; }
        public DbSet<Auction>Auctions{ get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
    }
}
