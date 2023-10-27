using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Data;

namespace TARpe21ShopVaitmaa.ApplicationServices.Services
{
    public class RealEstatesServices
    {
        private readonly TARpe21ShopVaitmaaContext _context;
        public RealEstatesServices
            (
            TARpe21ShopVaitmaaContext context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
