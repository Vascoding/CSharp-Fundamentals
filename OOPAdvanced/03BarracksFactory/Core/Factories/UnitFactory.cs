using System.Reflection;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string NameSpace = "_03BarracksFactory.Models.Units.";
        public IUnit CreateUnit(string unitType)
        {
            Type unit = Type.GetType(NameSpace + unitType);
            IUnit boxInt = (IUnit)Activator.CreateInstance(unit);
            return boxInt;
        }
    }
}
