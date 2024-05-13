using _13MayWebApp.DAL;
using _13MayWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _13MayWebApp.Controllers
{
    public class MenuController : Controller
    {
        MenuVM vm=new MenuVM();
        AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            vm.Foods=_context.FoodItems.ToList();
            return View(vm);
        }
    }
}
