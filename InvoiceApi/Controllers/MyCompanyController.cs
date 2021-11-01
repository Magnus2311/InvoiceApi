using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Helpers.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoiceApi.Controllers
{
    [Route("api/my-company")]
    [ApiController]
    public class MyCompanyController : ControllerBase
    {
        private readonly IMyCompanyService _myCompanyService;

        public MyCompanyController(IMyCompanyService myCompanyService)
        {
            _myCompanyService = myCompanyService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateData(MyCompanyDTO myCompanyDTO)
        {
            await _myCompanyService.Update(myCompanyDTO);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetData()
        {
            var myCompany = await _myCompanyService.Get();
            return Ok(myCompany);
        }

        [HttpGet("search-by-bulstat")]
        public async Task<IActionResult> SearchByBulstat(string bulstat)
            => Ok(await _myCompanyService.SearchByBulstat(bulstat));
    }
}
