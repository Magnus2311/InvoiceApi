using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Interfaces;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Services
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
            await itemRepository.Delete(id.ToString());
        }
    }
}
