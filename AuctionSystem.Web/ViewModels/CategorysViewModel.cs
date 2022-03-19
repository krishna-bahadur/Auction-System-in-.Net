using AuctionSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSystem.Web.ViewModels
{
    public class CategorysListViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }

    }
   
   
    public class CategoryDetailViewModel : PageViewModel
    {
        public Category Category{ get; set; }

    }
    public class CategoryViewModel : PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Auction> Auctions { get; set; }

    }
  
  
}