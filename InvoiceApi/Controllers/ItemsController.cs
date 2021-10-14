using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
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

        [HttpPost("add")]
        public async Task<ItemDTO> Add(ItemDTO item)
        {
            item.UserId = "e5dccffc-c4d8-4cba-a886-7ef49f4bdd8a";
            if (ModelState.IsValid)
            {
                await itemService.Add(item);
                return item;
            }
            throw new Exception();
        }
        [HttpPost]
        public async Task<ItemDTO> Post(ItemDTO item)
        {
            
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
        public async Task Delete(int id) => itemService.Delete(id);
    }
}
