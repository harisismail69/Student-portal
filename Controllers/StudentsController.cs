using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
            [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
