using RecyclingStation.Models;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Strategies
{
    [Disposable]
    public class BurnableGarbageStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage, ProcessingData processingData)
        {
            return processingData;
        }
    }
}