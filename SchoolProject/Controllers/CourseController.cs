using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject;

namespace SchoolProject.Controllers
{
	public class CourseController : Controller
	{
        private readonly SchoolProjectContext _context;
        public CourseController(SchoolProjectContext context)
        {
            _context = context;
        }
		public async Task<IActionResult> Index()
		{
            if (_context.Courses == null)
            {
                return NotFound();
            }
            
            var model = await _context.Courses.ToListAsync();
            return View(model);
		}  
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name, Description")] Course course)
		{

				_context.Add(course);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
		}
	}
}