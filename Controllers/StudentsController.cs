using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Entity;

namespace WebApplication2.Controllers
{

    public class StudentsController : Controller
    {
        private readonly AppDbcontext dbContext;

        public StudentsController(AppDbcontext dbContext)
    {
            this.dbContext = dbContext;
        }
            [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewmodel)
        {
            var student = new Student
            {
                Name = viewmodel.Name,
                Email = viewmodel.Email,
                Phone = viewmodel.Phone,
                subscribed = viewmodel.subscribed
            };
            await dbContext.students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
