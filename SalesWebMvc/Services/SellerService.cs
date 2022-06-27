using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
  public class SellerService
  {
    private readonly SalesWebMvcContext _ctx;
    public SellerService(SalesWebMvcContext context)
    {
      _ctx = context;
    }
    public List<Seller> FindAll()
    {
      return _ctx.Seller.OrderBy(s => s.Name).ToList();
    }
    public void Insert(Seller seller)
    {
      _ctx.Add(seller);
      _ctx.SaveChanges();
    }
  }
}
