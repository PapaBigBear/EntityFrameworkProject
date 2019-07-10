using CMDDto.Models;
using DomainLayer.Models;

namespace ServiceLayer.Mappers
{
    public class ItemMapper
    {
        public static Item DtoToDomain(ItemDTO itemDto)
        {
            if(itemDto != null)
            {
                return new Item()
                {
                    ItemId = itemDto.ItemId,
                    ItemName = itemDto.ItemName,
                    ItemNumber = itemDto.ItemNumber,
                    Unit = itemDto.Unit,
                    Price = itemDto.Price,
                    Height = itemDto.Height,
                    Width = itemDto.Width,
                    WeightInGrams = itemDto.WeightInGrams
                };
            }

            return null;
        }

        public static ItemDTO DomainToDto(Item item)
        {
            if (item != null)
            {
                return new ItemDTO()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemNumber = item.ItemNumber,
                    Unit = item.Unit,
                    Price = item.Price,
                    Height = item.Height,
                    Width = item.Width,
                    WeightInGrams = item.WeightInGrams
                };
            }

            return null;
        }
    }
}
