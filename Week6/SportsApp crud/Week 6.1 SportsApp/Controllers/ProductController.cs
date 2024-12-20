using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class ProductController : Controller{

    private readonly StoreDbContext _context;

    public ProductController(StoreDbContext context){
            _context = context;
        }
    public ActionResult Index(){
        return View(_context.Products);
    }

    [HttpGet]
     public ActionResult Create(){
        return View();
    }

    [HttpPost]
     public async Task<ActionResult> Create(Product product){
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

   [HttpGet]
    public async Task<IActionResult> Update(long? productId){
        var product = await _context.Products.FindAsync(productId);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, Product product){
        product.ProductID = id;

        //if(ModelState.IsValid){
            try{
                _context.Update(product);
                await _context.SaveChangesAsync();
            }catch(Exception){
                throw;
            }
            return RedirectToAction("Index");
        //}

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long? id){
        var product = await _context.Products.FindAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] long id){
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}