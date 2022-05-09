using ParcelOrders.Services;
using System.Linq;

namespace ParcelOrders
{
    public class ParcelOrderService
    {
        public ParcelOrderResult CalculateCost(ParcelOrder parcelOrder)
        {
            var result = new ParcelOrderResult();

            foreach (var parcelDimensions in parcelOrder.ParcelsDimensions)
            {
                var parcelResult = ParcelItem.Create(parcelDimensions);

                result.ParcelResults.Add(parcelResult);
            }

            var parcelsCost = result.ParcelResults.Sum(x => x.Cost);

            if (parcelOrder.IsSpeedyShipping)
            {
                var speedyShipping = new SpeedyShipping(parcelsCost);

                result.ParcelResults.Add(speedyShipping);
            }

            return result;
        }
    }
}
