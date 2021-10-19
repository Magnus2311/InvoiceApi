using InvoiceApi.Common.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvoiceApi.Controllers
{
    [Route("api/my-company")]
    [ApiController]
    public class MyCompanyController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UpdateData(CompanyDTO myCompany)
        {
            return Ok();
        }
    }
}
