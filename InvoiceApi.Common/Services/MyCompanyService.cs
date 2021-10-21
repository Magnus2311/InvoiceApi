using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Interfaces.Mappers;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Interfaces;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Services
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

        public async Task Update(MyCompanyDTO myCompanyDTO)
        {
            var myCompany = _mapper.MapMyCompanyDTO(myCompanyDTO);
            await _repository.AddOrUpdate(myCompany);
        }
    }
}
