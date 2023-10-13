using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Data;
using TARpe21ShopVaitmaa.Models;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        public SpaceshipsController( TARpe21ShopVaitmaaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
    }
}
