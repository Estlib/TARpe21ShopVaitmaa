using Microsoft.AspNetCore.Mvc;
using TARpe21ShopVaitmaa.Core.ServiceInterface;
using TARpe21ShopVaitmaa.Data;
using TARpe21ShopVaitmaa.Models.RealEstate;
using TARpe21ShopVaitmaa.Models.Spaceship;

namespace TARpe21ShopVaitmaa.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstates;
        private readonly TARpe21ShopVaitmaaContext _context;
        public RealEstatesController
            (
            IRealEstatesServices realEstates,
            TARpe21ShopVaitmaaContext context
            )
        {
            _realEstates = realEstates;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    SquareMeters = x.SquareMeters,
                    Price = x.Price,
                    IsPropertySold = x.IsPropertySold,
                });
            return View(result);
        }
    }
}
