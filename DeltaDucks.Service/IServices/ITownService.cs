﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaDucks.Models;

namespace DeltaDucks.Service.IServices
{
    public interface ITownService
    {
        Town GetTownByName(string town);
    }
}
