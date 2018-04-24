using System.Collections.Generic;
using MilitaryElit.Models;

namespace MilitaryElit.Interfaces
{
    public interface ICommando
    {
        HashSet<IAuxiliary> Missions { get; }
    }
}