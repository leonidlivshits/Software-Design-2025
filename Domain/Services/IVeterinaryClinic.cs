using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooManagement.Domain;

namespace ZooManagement.Services
{
    public interface IVeterinaryClinic
    {
        bool Examine(Animal animal);
    }
}

