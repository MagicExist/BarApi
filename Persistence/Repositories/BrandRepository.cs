
using BarApi.Models;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BrandRepository : IbrandRepository
    {
        private readonly DbContextBeer _dbContextBeer;
        public BrandRepository(DbContextBeer dbContextBeer) 
        {
            _dbContextBeer = dbContextBeer;
        }

        public async Task<Brand[]> GetAllBrandsAsync()
        {
            return await _dbContextBeer.Brands.ToArrayAsync();
        }

        public async Task<Brand> AddBrandAsync(Brand newBrand)
        {
            await _dbContextBeer.AddAsync(newBrand);
            await _dbContextBeer.SaveChangesAsync();
            return newBrand;
        }

        public async Task<bool> DeleteBrandAsync(Brand brandDelete)
        {
            var brand = await _dbContextBeer.Brands.FindAsync(brandDelete.Id);
            if (brand != null) 
            {
                _dbContextBeer.Brands.Remove(brand);
                await _dbContextBeer.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<(Brand, Brand)> UpdateBrandAsync(Brand brandUpdate)
        {
            var brand = await _dbContextBeer.Brands.FindAsync(brandUpdate.Id);
            if (brand == null) 
            {
                return (null, null);
            }
            var oldBrand = new Brand()
            {
                Id = brand.Id,
                Name = brand.Name,
            };
            _dbContextBeer.Brands.Update(brandUpdate);
            await _dbContextBeer.SaveChangesAsync();
            return (oldBrand, brand);
        }
    }
}
