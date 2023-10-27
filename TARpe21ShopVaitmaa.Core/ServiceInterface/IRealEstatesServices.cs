﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopVaitmaa.Core.Domain;
using TARpe21ShopVaitmaa.Core.Dto;

namespace TARpe21ShopVaitmaa.Core.ServiceInterface
{
    public interface IRealEstatesServices
    {
        Task<RealEstate> GetAsync();
        Task<RealEstate> Create(RealEstateDto dto);
    }
}
