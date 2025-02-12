﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooManagement.Domain;

namespace ZooManagement.Services
{
    public interface IVeterinaryClinic
    {
        /// <summary>
        /// Осмотр животного.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        bool Examine(Animal animal);
    }
}

