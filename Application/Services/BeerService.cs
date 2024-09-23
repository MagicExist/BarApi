using Application.DTOs.BeerDTOs;
using Domain.Entities;
using Domain.Repository;

namespace Application.Services
{
    public class BeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        //Get all beers
        public async Task<BeerDTO[]?> GetAllBeersAsync()
        {
            
            var beerList = await _beerRepository.GetAllBeersAsync();
            if (beerList != null || beerList.Length > 0)
            {
                var beerListDto = new BeerDTO[beerList.Length];
                for (int i = 0; i < beerList.Length; i++)
                {
                    var beerDto = new BeerDTO()
                    {
                        Id = beerList[i].Id,
                        Name = beerList[i].Name,
                        Quantity = beerList[i].Quantity,
                        BrandId = beerList[i].BrandId
                    };
                    beerListDto[i] = beerDto;
                }
                return beerListDto;
            }
            return null;
            
        }
        //Add a new beer
        public async Task<BeerDTO> AddBeerAsync(Beer beer)
        {
            var responseBeer = await _beerRepository.AddBeerAsync(beer);
            return new BeerDTO
            {
                Id = responseBeer.Id,
                Name = responseBeer.Name,
                BrandId = responseBeer.BrandId,
                Quantity = responseBeer.Quantity
            };
        }
        //Update a beer
        public async Task<(BeerDTO?, BeerDTO?)> UpdateBeerAsync(Beer beer)
        {
            var (oldBeer,newBeer) = await _beerRepository.UpdateBeerAsync(beer);
            if (oldBeer == null && newBeer == null)
            {
                return (null,null);
            }
            return  (
                      new BeerDTO //Old Beer
                      {
                           Id = oldBeer.Id,
                           Name = oldBeer.Name,
                           BrandId = oldBeer.BrandId,
                           Quantity = oldBeer.Quantity
                      },
                      new BeerDTO //New Beer
                      {
                          Id = newBeer.Id,
                          Name = newBeer.Name,
                          BrandId = newBeer.BrandId,
                          Quantity = newBeer.Quantity
                      }
                      );
        }
        //Delete a beer
        public async Task<bool> DeleteBeerAsync(Beer beer)
        {
            var wasDeleted = await _beerRepository.DeleteBeerAsync(beer);
            return wasDeleted;
        }
        //Filter Beers by brand
        public async Task<BeerDTO[]?> GetBeersByBrandAsync(string brandName) 
        {
            var beerList = await _beerRepository.GetBeersByBrandAsync(brandName);
            if (beerList == null || beerList.Length <= 0)
            {
                return null;
            }
            var beerListDto = new BeerDTO[beerList.Length];
            for (int i = 0; i < beerList.Length; i++) 
            {
                var beerDto = new BeerDTO
                {
                    Id = beerList[i].Id,
                    Name = beerList[i].Name,
                    Quantity = beerList[i].Quantity,
                    BrandId = beerList[i].BrandId
                };
                beerListDto[i] = beerDto;
            }
            return beerListDto;
        }
    }
}
