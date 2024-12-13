﻿using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.Id == id);
            return user.First();
        }

        public async Task Create(User model)
        {
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.Id == id);

            _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }

        public async Task<List<User>> GetByRole(string role)
        {
            return await _repositoryWrapper.User
                .FindByCondition(x => x.Role == role);
        }
    }
}