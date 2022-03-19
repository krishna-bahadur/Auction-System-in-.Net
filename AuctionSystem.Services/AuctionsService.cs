using AuctionSystem.Data;
using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Services
{
    public class AuctionServices
    {
        public List<Auction> GetAuction()
        {
            DBContext context = new DBContext();
            return context.Auctions.ToList();
        }
        public List<Auction> GetPromotedAuction()
        {
            DBContext context = new DBContext();
            return context.Auctions.Take(4).ToList();
        }

        public Auction GetAuctionId(int Id)
        {
            DBContext context = new DBContext();
            return context.Auctions.Find(Id);
        }
        public void AddAuction(Auction auction)
        {
            DBContext context = new DBContext();
            context.Auctions.Add(auction);
            context.SaveChanges();
        }

        public void UpdateAuction(Auction auction)
        {
            DBContext context = new DBContext();
            context.Entry(auction).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAuction(Auction auction)
        {
            DBContext context = new DBContext();
            context.Entry(auction).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
