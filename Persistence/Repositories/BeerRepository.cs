
using BarApi.Models;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DbContextBeer _dbContextBeer;
        public BeerRepository(DbContextBeer dbContextBeer) 
        {
            _dbContextBeer = dbContextBeer;
        }
        public Task<Beer[]> GetAllBeersAsync()
        {
            return _dbContextBeer.Beers.AsNoTracking().ToArrayAsync();
        }

        public Beer AddBeer(Beer beer)
        {
            _dbContextBeer.Beers.Add(beer);
            _dbContextBeer.SaveChanges();
            return beer;
        }

        public async Task<bool> DeleteBeerAsync(Beer beer)
        {
            if (_dbContextBeer.Beers.FirstOrDefault(beer) != null)
            {
                _dbContextBeer.Beers.Remove(beer);
                await _dbContextBeer.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Beer[]> GetBeersByBrandAsync(string brandName)
        {
             return await _dbContextBeer.Beers.AsNoTracking().Include(b => b.Brand).Where(b => b.Brand.Name == brandName).ToArrayAsync();
        }

        public async Task<(Beer,Beer)> UpdateBeerAsync(Beer updateBeer)
        {
            var beer = _dbContextBeer.Beers.Find(updateBeer.Id);
            if (beer == null)
            {
                return (null,null);
            }
            var oldBeer = new Beer
            {
                Id = beer.Id,
                Brand = beer.Brand,
                BrandId = beer.Id,
                Name = beer.Name,
                Quantity = beer.Quantity,
            };
            _dbContextBeer.Entry(beer).CurrentValues.SetValues(updateBeer);
            await _dbContextBeer.SaveChangesAsync();
            return (oldBeer,beer);
        }
    }
}
