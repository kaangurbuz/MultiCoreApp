﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.Service.Services
{
    public class UserService : Service<User>,IUserService
    {
        public UserService(IUnitOfWork unit, IRepository<User> repo) : base(unit, repo)
        {
        }
    }
}
