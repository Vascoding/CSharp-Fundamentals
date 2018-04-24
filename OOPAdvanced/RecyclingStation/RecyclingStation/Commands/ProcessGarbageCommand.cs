using System;
using System.Reflection;
using RecyclingStation.Models;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Strategies;

namespace RecyclingStation.Commands
{
    public class ProcessGarbageCommand : Command
    {
        private IWaste garbage;
        private StrategyHolder strategyHolder;
        private string wasteNameSpace = "RecyclingStation.Models.";
        public override string Execute(string[] args, IGarbageProcessor garbageProcessor)
        {
            string name = args[0];
            double weight = double.Parse(args[1]);
            double volumePerKg = double.Parse(args[2]);
            string waste = args[3];
            Type wasteType = Type.GetType(wasteNameSpace + waste);
            
            object[] par =
            {
                name,
                weight,
                volumePerKg
            };
            ConstructorInfo constructor = wasteType.GetConstructor(BindingFlags.Instance | BindingFlags.Public,
               null, new []{typeof(string), typeof(double), typeof(double)}, null);
            IWaste garbage =  (Recyclable)constructor.Invoke(par);
            var attr = garbage.GetType().CustomAttributes;
            
            
            garbageProcessor.ProcessWaste(garbage);
            strategyHolder.AddStrategy(wasteType, new RecyclableGarbageStrategy());
            return $"“{weight} kg of {name} successfully processed!";
        }
    }
}