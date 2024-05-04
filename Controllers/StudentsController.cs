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

        [HttpGet]

        public async Task<IActionResult> list()
        {
            var students = await dbContext.students.ToListAsync();

            return View(students);
        }

        [HttpGet]
        
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.students.FindAsync(id);

            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.students.FindAsync(viewModel.ID);

            if(student != null)
            {
                student.Name = viewModel.Name;  
                student.Email = viewModel.Email;    
                student.Phone = viewModel.Phone;    
                student.subscribed = viewModel.subscribed;

                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("list", "Students");
        }


    }
}
