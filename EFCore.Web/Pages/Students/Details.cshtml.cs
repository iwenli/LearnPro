using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCore.Web.Data;
using EFCore.Web.Models;

namespace EFCore.Web.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly EFCore.Web.Data.SchoolContext _context;

        public DetailsModel(EFCore.Web.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(m=>m.Enrollments)
                .ThenInclude(m=>m.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
