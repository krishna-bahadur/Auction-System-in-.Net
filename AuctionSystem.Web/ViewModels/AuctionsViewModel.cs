using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Web.ViewModels
{
    public class AuctionsListViewModel : PageViewModel
    {
        public List<Auction> Auctions { get; set; }

    }
   
    public class AuctionsViewModel : PageViewModel
    {
       
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuction { get; set; }

    }
    public class AuctionDetailViewModel : PageViewModel
    {
        public Auction Auction { get; set; }

    }
    public class CreateAuctionViewModel : PageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string AuctionPictures { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
        public int Id { get; set; }
        public List<AuctionPicture> AuctionPicturesList { get; set; }
       

    }
  
}