using AutoMapper;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Services
{
    public class MapItemService : IMapItemService
    {
        private readonly IMapper _mapper;

        public MapItemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Item ItemDTOToItem(ItemDTO itemDTO)
        {
            return _mapper.Map<Item>(itemDTO);
        }

        public ItemDTO ItemToItemDTO(Item item)
        {
            return _mapper.Map<ItemDTO>(item);
        }

        public List<Item> ListItemDTOToListItem(List<ItemDTO> itemDTO)
        {
            return _mapper.Map<List<Item>>(itemDTO);
        }

        public List<ItemDTO> ListItemToListItemDTO(List<Item> item)
        {
            return _mapper.Map<List<ItemDTO>>(item);
        }
    }
}
