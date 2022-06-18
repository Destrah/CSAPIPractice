using CSAPIPractice.DTOs;
using CSAPIPractice.Entities;

namespace CSAPIPractice
{
    public static class Extensions
    {
        public static ItemDTO AsDto(this Item item)
        {
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
        public static PlayerDTO AsDto(this Player player)
        {
            return new PlayerDTO
            {
                Identifier = player.Identifier,
                FirstName = player.FirstName,
                LastName = player.LastName,
                Job = player.Job
            };
        }
    }
}