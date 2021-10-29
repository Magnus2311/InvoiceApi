using InvoiceApi.Common.Helpers;
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
    public class PartnersController : ControllerBase
    {
        private IPartnerService partnerService;
        public PartnersController(IPartnerService _partnerService)
        {
            partnerService = _partnerService;
        }

        [HttpGet]
        public string Get()
        {
            return "Working";
        }


        [HttpGet("all")]
        public async Task<IEnumerable<PartnerDTO>> GetAllItems()
        {
            return await partnerService.GetAllPartnersAsync();
        }

        [HttpPost("add")]
        public async Task<PartnerDTO> Add(PartnerDTO partner)
        {
            partner.UserId = GlobalHelpers.CurrentUser.Id;
            if (ModelState.IsValid)
            {
                await partnerService.Add(partner);
                return partner;
            }
            throw new Exception();
        }

        [HttpPut]
        public async Task Put(PartnerDTO partner) => await partnerService.Update(partner);

        [HttpDelete]
        public async Task Delete(int id)
        {
            await partnerService.Delete(id);

        }
    }
}
