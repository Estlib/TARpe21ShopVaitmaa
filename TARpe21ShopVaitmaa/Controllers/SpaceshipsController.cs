using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Data;

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
                    ID = x.ID,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
        }
    }
}
