using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

 [Route("api/[controller]")]
    [ApiController]
public class HHApiController:ControllerBase
{
    private readonly AppDbContext _context;
    public HHApiController(AppDbContext context)
    {
         _context = context;
    }

[HttpGet]
[Route("hhdtls")]
public object Getrecords()
    {
var cust = _context.HouseHolder.ToList();
return cust;
    }
//adding code manually for grouping data
[HttpGet]
[Route("hhdtlsgrp")]
public IActionResult GroupDetails()
{
    List<HouseHolder> hs = new List<HouseHolder>();
    var details = _context.HouseHolder.GroupBy(n => n.profession).Select(group =>
             new
             {
                 profession = group.Key,
                 Count = group.Count(),
                
             }).ToList();

   
    return Ok(details);
}
 // GET: HHolder/Create
 [HttpPost]
 
 public IActionResult Create([Bind("Id,name,hno,profession")] HouseHolder houseHolder)
 {
     if (ModelState.IsValid)
     {
         _context.Add(houseHolder);
         _context.SaveChanges();
         return Created();
     }
     return null;
 }
}