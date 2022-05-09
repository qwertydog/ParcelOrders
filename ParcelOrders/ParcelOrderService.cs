using ParcelOrders.Services;
using System.Linq;

namespace ParcelOrders
{
    public class ParcelOrderService
    {
        private const decimal SmallParcelCost = 3;
        private const decimal MediumParcelCost = 8;
        private const decimal LargeParcelCost = 15;
        private const decimal ExtraLargeParcelCost = 25;

        public ParcelOrderResult CalculateCost(ParcelOrder parcelOrder)
        {
            var result = new ParcelOrderResult();

            foreach (var parcelDimensions in parcelOrder.ParcelsDimensions)
            {
                var parcelResult = new ParcelResult();

                if (parcelDimensions.AreAllDimensionsWithin(10))
                {
                    parcelResult.OrderItemCategory = OrderItemCategory.SmallParcel;
                    parcelResult.Cost = SmallParcelCost;
                }
                else if (parcelDimensions.AreAllDimensionsWithin(50))
                {
                    parcelResult.OrderItemCategory = OrderItemCategory.MediumParcel;
                    parcelResult.Cost = MediumParcelCost;
                }
                else if (parcelDimensions.AreAllDimensionsWithin(100))
                {
                    parcelResult.OrderItemCategory = OrderItemCategory.LargeParcel;
                    parcelResult.Cost = LargeParcelCost;
                }
                else
                {
                    parcelResult.OrderItemCategory = OrderItemCategory.ExtraLargeParcel;
                    parcelResult.Cost = ExtraLargeParcelCost;
                }

                result.ParcelResults.Add(parcelResult);
            }

            var parcelsCost = result.ParcelResults.Sum(x => x.Cost);

            if (parcelOrder.IsSpeedyShipping)
            {
                result.ParcelResults.Add(new ParcelResult
                {
                    OrderItemCategory = OrderItemCategory.SpeedyShipping,
                    Cost = parcelsCost
                });
            }

            return result;
        }
    }
}
