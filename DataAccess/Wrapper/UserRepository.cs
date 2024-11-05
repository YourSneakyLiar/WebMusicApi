using Domain.Models;
using Domain.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WebMusicAppContext repositoryContext)
             : base(repositoryContext)
        {
        }


    }
}
