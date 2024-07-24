using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.BloggDbContext;
using MvcProject.Models;
using MvcProject.Models.Entities;
using System.Numerics;

namespace MvcProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;
        public StudentsController( StudentContext context )
        {
            
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(AddViewModel viewmodel)
        {
            var student = new Student
            {
                name = viewmodel.name,
                age = viewmodel.age,
                email = viewmodel.email,
                phone = viewmodel.phone,
                subscribed = viewmodel.subscribed

            };

            await _context.students.AddAsync(student);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]


        public async Task<IActionResult> List()
        {
            var students = await _context.students.ToListAsync();
            return View(students);
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(int id)
        {
            var students = await _context.students.FindAsync(id);
            return View(students);
        }


        [HttpPost]


        public async Task<IActionResult> Edit(Student studentsetail)
        {
            var students = await _context.students.FindAsync(studentsetail.id);
            if (students != null)
            {
                students.name = studentsetail.name;
                students.phone= studentsetail.phone;
                students.subscribed= studentsetail.subscribed;
                students.email= studentsetail.email;
                students.age= studentsetail.age;
                students.phone=studentsetail.phone;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("List","Students");
           
        }

        [HttpPost]  

        public async Task<IActionResult> Delete(Student viewmodeld)
        {
            var student = await _context.students.AsNoTracking().FirstOrDefaultAsync(x=>x.id==viewmodeld.id);
            if(student != null)
            {
                _context.students.Remove(viewmodeld);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
           
        }
    }
}
