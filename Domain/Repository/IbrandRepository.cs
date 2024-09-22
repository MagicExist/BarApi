using Domain.Entities;
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
        public Task<Brand> AddBrandAsync(Brand brand);
        //Update an existing brand
        public Task<(Brand, Brand)> UpdateBrandAsync(Brand brand);
        //Delete one brand
        public Task<bool> DeleteBrandAsync(Brand brand);
    }
}
