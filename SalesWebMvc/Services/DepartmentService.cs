using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
  public class DepartmentService
  {
    private readonly SalesWebMvcContext _ctx;
    public DepartmentService(SalesWebMvcContext context)
    {
      _ctx = context;
    }
    public List<Department> FindAll()
    {
      return _ctx.Department.OrderBy(d => d.Name).ToList();
    }
  }
}
