using RecyclingStation.Models;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Strategies
{
    [Disposable]
    public class RecyclableGarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage, ProcessingData processingData)
        {
            var energyUsed = (garbage.Weight*garbage.VolumePerKg) * 0.5;
            var capitalEarned = 400*garbage.Weight;
            processingData.EnergyBalance -= energyUsed;
            processingData.CapitalBalance += capitalEarned;
            return processingData;
        }
    }
}