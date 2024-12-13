using Domain.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositories;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper

    {
        private WebMusicAppContext _repoContext;

        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if(_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }



        public RepositoryWrapper(WebMusicAppContext repositoryContext) 
        { 
        
        
           _repoContext = repositoryContext;   
        
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }



    }
}
