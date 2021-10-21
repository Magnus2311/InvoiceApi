using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IMapItemService
    {
        Item ItemDTOToItem(ItemDTO itemDTO);
        ItemDTO ItemToItemDTO(Item item);
        List<Item> ListItemDTOToListItem(List<ItemDTO> itemDTO);
        List<ItemDTO> ListItemToListItemDTO(List<Item> item);
    }
}
