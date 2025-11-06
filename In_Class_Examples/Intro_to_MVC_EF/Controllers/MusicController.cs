using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intro_to_MVC_EF.Models;

namespace Intro_to_MVC_EF.Controllers
{
    public class MusicController : Controller
    {
        private readonly DB_128040_practiceContext _context;

        public MusicController(DB_128040_practiceContext context)
        {
            _context = context;
        }

        // GET: Music
        public async Task<IActionResult> Index()
        {
            var orderedMusic = _context.Spotifies.OrderByDescending(x => x.Popularity).ToListAsync().Result;

            return View(orderedMusic);
        }

        // GET: Music/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spotify = await _context.Spotifies
                .FirstOrDefaultAsync(m => m.Index == id);
            if (spotify == null)
            {
                return NotFound();
            }

            return View(spotify);
        }

      
        private bool SpotifyExists(int id)
        {
            return _context.Spotifies.Any(e => e.Index == id);
        }
    }
}
