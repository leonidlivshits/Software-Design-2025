using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;
using ZooManagement.Services;
/// <summary>
/// Это мок ветеринарной клиники
/// </summary>
public class MockVeterinaryClinic : IVeterinaryClinic
{
    private readonly bool _examineResult;

    public MockVeterinaryClinic(bool examineResult)
    {
        _examineResult = examineResult;
    }

    public bool Examine(Animal animal)
    {
        return _examineResult;
    }
}

