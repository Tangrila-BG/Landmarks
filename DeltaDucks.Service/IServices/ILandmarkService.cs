using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Models;

namespace DeltaDucks.Service.Interfaces
{
    public interface ILandmarkService
    {
        Landmark GetLandmarkById(int id);
    }
}
