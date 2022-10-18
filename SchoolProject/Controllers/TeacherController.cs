using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject;

namespace SchoolProject.Controllers
{
	public class TeacherController : Controller
	{
        private readonly SchoolProjectContext _context;
        public TeacherController(SchoolProjectContext context)
        {
            _context = context;
        }
		public async Task<IActionResult> Index()
		{
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            
            var model = await _context.Teachers.ToListAsync();
            return View(model);
		}  
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FirstName, LastName")] Teacher teacher)
		{

				_context.Add(teacher);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
		}
	}
}