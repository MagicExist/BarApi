﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IbrandRepository
    {
        //Get all brands
        public Task<Brand[]> GetAllBrandsAsync();
        //Add a new brand
        public Task<Brand> AddBrandAsync();
        //Update an existing brand
        public Task<Brand> UpdateBrandAsync();
        //Delete one brand
        public Task<bool> DeleteBrandAsync();
    }
}
