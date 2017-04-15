using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Data.IRepositories;
using DeltaDucks.Models;
using DeltaDucks.Service.IServices;

namespace DeltaDucks.Service.Services
{
    class TownService : ITownService
    {
        private readonly ITownRepository _townRepository;

        public TownService(ITownRepository townRepository)
        {
            this._townRepository = townRepository;
        }

        public Town GetTownByName(string name)
        {
            return this._townRepository.GetByName(name);
        }
    }
}
