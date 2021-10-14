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
    public class MapUserService : IMapUserService
    {
        private readonly IMapper _mapper;

        public MapUserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User UserDTOToUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            return user;

        }

        public UserDTO UserToUserDTO(User user)
        {
            return _mapper.Map<UserDTO>(user);
        }

        public List<User> ListUserDTOToListUser(List<UserDTO> userDTO)
        {
            return _mapper.Map<List<User>>(userDTO);
        }

        public List<UserDTO> ListUserToListUserDTO(List<User> user)
        {
            return _mapper.Map<List<UserDTO>>(user);
        }
    }
}
