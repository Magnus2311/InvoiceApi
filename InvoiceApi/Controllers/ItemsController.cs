using InvoiceApi.Common.Helpers;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Common.Models.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemService itemService;
        public ItemsController(IItemService _itemService)
        {
            itemService = _itemService;
        }

        [HttpGet]
        public string Get()
        {
            return "Working";
        }


        [HttpGet("all")]
        public async Task<IEnumerable<ItemDTO>> GetAllItems()
        {
            return await itemService.GetAllItemsAsync();
        }

        [HttpPost("add")]
        public async Task<ItemDTO> Add(ItemDTO item)
        {
            item.UserId = GlobalHelpers.CurrentUser.Id;
            if (ModelState.IsValid)
            {
                await itemService.Add(item);
                return item;
            }
            throw new Exception();
        }

        [HttpPut]
        public async Task Put(ItemDTO item) => await itemService.Update(item);

        [HttpDelete]
        public async Task Delete(int id) => await itemService.Delete(id);
    }
}
