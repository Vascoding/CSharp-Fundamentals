using System.Collections.Generic;
using MilitaryElit.Models;

namespace MilitaryElit.Interfaces
{
    public interface ILeutenantGeneral
    {
        HashSet<ISoldier> Privates { get; }
    }
}