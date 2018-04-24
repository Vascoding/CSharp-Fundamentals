using System.Collections.Generic;
using MilitaryElit.Models;

namespace MilitaryElit.Interfaces
{
    public interface IEngineer
    {
        HashSet<IAuxiliary> Repairs { get; }
    }
}