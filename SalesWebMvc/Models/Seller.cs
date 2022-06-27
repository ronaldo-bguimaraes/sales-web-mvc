﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
  public class Seller
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public ICollection<SalesRecord> Sales { get; set; }
    public Seller()
    {
      Sales = new List<SalesRecord>();
    }
    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department) : this()
    {
      Id = id;
      Name = name;
      Email = email;
      BirthDate = birthDate;
      BaseSalary = baseSalary;
      Department = department;
    }
    public void AddSales(SalesRecord salesRecord)
    {
      Sales.Add(salesRecord);
    }
    public void RemoveSales(SalesRecord salesRecord)
    {
      Sales.Remove(salesRecord);
    }
    public double TotalSales(DateTime initial, DateTime final)
    {
      return Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
    }
  }
}
