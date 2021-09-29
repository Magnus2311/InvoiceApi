﻿using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapUserService mapUserService;

        public UserService(IUserRepository _userRepository,
            IMapUserService _mapUserService)
        {
            userRepository = _userRepository;
            mapUserService = _mapUserService;
        }

        public async Task AddUser(UserDTO user)
        {
           await userRepository.Add(mapUserService.UserDTOToUser(user));
        }

        public async Task ConfirmEmailAsync(string email)
        {
            await userRepository.ConfirmEmailAsync(email);
        }

        public async Task Delete(string username)
        {
            await userRepository.Delete(username);
        }

        public async Task<UserDTO> FindByUsernameAsync(string username)
        {
            var user = await userRepository.FindByUsernameAsync(username);
            return mapUserService.UserToUserDTO(user);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = await userRepository.GetAll();
            return mapUserService.ListUserToListUserDTO(users);
        }

        public async Task<bool> Login(UserDTO user)
        {
            return await userRepository.Login(mapUserService.UserDTOToUser(user));
        }

        public async Task<bool> TryChangePasswordAsync(UserDTO user, string newPassword)
        {
            return await userRepository.TryChangePasswordAsync(mapUserService.UserDTOToUser(user), newPassword);
        }

        public async Task UpdateRefreshToken(UserDTO user)
        {
            await userRepository.UpdateRefreshToken(mapUserService.UserDTOToUser(user));
        }
    }
}
