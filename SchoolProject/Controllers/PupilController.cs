using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject;

namespace SchoolProject.Controllers
{
	public class PupilController : Controller
	{
        private readonly SchoolProjectContext _context;
        public PupilController(SchoolProjectContext context)
        {
            _context = context;
        }
		public async Task<IActionResult> Index()
		{
            if (_context.Pupils == null)
            {
                return NotFound();
            }
            
            var model = await _context.Pupils.ToListAsync();
            return View(model);
		}  
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FirstName, LastName, YearGroup")] Pupil pupil)
		{

				_context.Add(pupil);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
		}
	}
}