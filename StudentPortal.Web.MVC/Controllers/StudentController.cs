using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> List()
        {
            var students = await _dbContext.Students.ToListAsync();

            return View(students);
            //return Ok(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student entity)
        {
            var student = await _dbContext.Students.FindAsync(entity.Id);

            if (student is not null)
            {
                student.Name = entity.Name;
                student.Email = entity.Email;
                student.Phone = entity.Phone;
                student.Subscribed = entity.Subscribed;
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student entity)//(Guid id)
        {
            //Occurs Error "The instance of entity type 'Student' cannot be tracked because another instance with the same key value for {id} is already being tracked."
            //var student = await _dbContext.Students.FindAsync(entity.Id); 
            var student = await _dbContext.Students
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (student is not null)
            {
                _dbContext.Students.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
