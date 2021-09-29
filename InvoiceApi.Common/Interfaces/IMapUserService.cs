using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IMapUserService
    {
        User UserDTOToUser(UserDTO userDTO);
        UserDTO UserToUserDTO(User user);
        List<User> ListUserDTOToListUser(List<UserDTO> userDTO);
        List<UserDTO> ListUserToListUserDTO(List<User> user);
    }
}
