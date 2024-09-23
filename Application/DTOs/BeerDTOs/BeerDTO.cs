
namespace Application.DTOs.BeerDTOs
{
    public class BeerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Quantity { get; set; }

        public int? BrandId { get; set; }
    }
}
