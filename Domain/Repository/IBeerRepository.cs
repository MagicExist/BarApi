
using Domain.Entities;

namespace Domain.Repository
{
    public interface IBeerRepository
    {
        //Get all beers
        public Task<Beer[]>GetAllBeersAsync();
        //Add a new beer
        public Beer AddBeer(Beer beer);
        //Update a beer
        public Task<Beer> UpdateBeerAsync();
        //Delete a beer
        public Task<bool> DeleteBeerAsync();
        //Filter Beers by brand
        public Task<Beer[]> GetBeersByBrandAsync();
    }
}
