using InvoiceApi.Common.Helpers;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Interfaces.Mappers;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Interfaces;
using System.Threading.Tasks;

namespace InvoiceApi.Services
{
    public class MyCompanyService : IMyCompanyService
    {
        private readonly IMyCompanyRepository _repository;
        private readonly IMapMyCompanyService _mapper;

        public MyCompanyService(IMyCompanyRepository repository,
            IMapMyCompanyService mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MyCompanyDTO> Get()
            => _mapper.MapMyCompanyToDTO(await _repository.GetByUserId(GlobalHelpers.CurrentUser.Id));

        public async Task Update(MyCompanyDTO myCompanyDTO)
        {
            var myCompany = _mapper.MapMyCompanyDTO(myCompanyDTO);
            myCompany.UserId = GlobalHelpers.CurrentUser.Id;
            await _repository.AddOrUpdate(myCompany);
        }
    }
}
