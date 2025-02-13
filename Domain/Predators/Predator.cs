﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Predators
{
    public abstract class Predator : Animal
    {
        protected Predator(string name, uint food, uint number)
            : base(name, food, number)
        {
        }
    }
}
