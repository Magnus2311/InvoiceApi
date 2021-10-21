using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Interfaces.Mappers;
using InvoiceApi.Common.Models.Database;
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
        public async Task<IActionResult> UpdateData(MyCompanyDTO myCompanyDTO)
        {
            await _myCompanyService.Update(myCompanyDTO);

            return Ok();
        }
    }
}
