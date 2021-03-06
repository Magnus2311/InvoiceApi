using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Common.Models.Filter;
using InvoiceApi.Database.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository itemRepository;
        private IMapItemService mapItemService;

        public ItemService(IItemRepository _itemRepository,
            IMapItemService _mapItemService)
        {
            itemRepository = _itemRepository;
            mapItemService = _mapItemService;
        }

        public async Task Add(ItemDTO item)
        {
            var itm = mapItemService.ItemDTOToItem(item);
            await itemRepository.Add(itm);
        }

        public async Task Update(ItemDTO item)
        {
            await itemRepository.Update(mapItemService.ItemDTOToItem(item));
        }

        public async Task Delete(int id)
        {
            await itemRepository.Delete(id);
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
        {
            var items = await itemRepository.GetAllItems();
            return mapItemService.ListItemToListItemDTO(items);
        }

        public async Task<List<ItemDTO>> GetFilteredItemsAsync(ItemsFilterDTO filter)
        {
            var items = await itemRepository.GetFilteredItems(filter.Name,filter.Code,filter.Account,filter.FromAmount, filter.ToAmount, filter.Measure);
            return mapItemService.ListItemToListItemDTO(items);
        }
    }
}
