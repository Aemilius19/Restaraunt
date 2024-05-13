using _13MayWebApp.DAL;
using _13MayWebApp.Models;
using _13MayWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _13MayWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {

        MenuVM vm;
        
        AppDbContext _context;
        private readonly IWebHostEnvironment environment;

        public MenuController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            MenuVM vm = new MenuVM();
            vm.Foods=_context.FoodItems.ToList();
            
            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FoodItem fi)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            string path = environment.WebRootPath + @"\admin\Upload\fooditem\";
            string filename = Guid.NewGuid() + fi.ImgFile.FileName;
            fi.ImgUrl = filename;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                fi.ImgFile.CopyTo(stream);
                _context.FoodItems.Add(fi);
                _context.SaveChanges();
                
                
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var ffood=_context.FoodItems.FirstOrDefault(x=>x.ID== id);
            _context.FoodItems.Remove(ffood);
            _context.SaveChanges(true);
            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(_context.FoodItems.FirstOrDefault(x=>x.ID==id));
        }
        [HttpPost]
        public IActionResult Update(FoodItem fi)
        {
            FoodItem oldfood=_context.FoodItems.FirstOrDefault(x=>x.ID==fi.ID);

            return RedirectToAction("Index");
        }
    }
}
