using Microsoft.AspNetCore.Mvc;
using StudentPortal.Web.MVC.Data;
using StudentPortal.Web.MVC.Models;
using StudentPortal.Web.MVC.Models.Entities;

namespace StudentPortal.Web.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public StudentController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentVM model)
        {
            var student = new Student
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Subscribed = model.Subscribed
            };
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return View();
        }
    }
}
