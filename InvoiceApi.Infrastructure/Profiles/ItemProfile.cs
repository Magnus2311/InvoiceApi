using AutoMapper;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Infrastructure.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
        }
    }
}
