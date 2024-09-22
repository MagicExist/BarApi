
using Domain.Entities;

namespace Domain.Repository
{
    public interface IBeerRepository
    {
        //Get all beers
        public Task<Beer[]>GetAllBeersAsync();
        //Add a new beer
        public Task<Beer> AddBeerAsync(Beer beer);
        //Update a beer
        public Task<(Beer,Beer)> UpdateBeerAsync(Beer beer);
        //Delete a beer
        public Task<bool> DeleteBeerAsync(Beer beer);
        //Filter Beers by brand
        public Task<Beer[]> GetBeersByBrandAsync(string brandName);
    }
}
