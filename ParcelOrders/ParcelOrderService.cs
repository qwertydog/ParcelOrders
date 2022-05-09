using ParcelOrders.Services;
using System.Collections.Generic;

namespace ParcelOrders
{
    public class ParcelOrderService
    {
        private const decimal SmallParcelCost = 3;
        private const decimal MediumParcelCost = 8;
        private const decimal LargeParcelCost = 15;
        private const decimal ExtraLargeParcelCost = 25;

        public ParcelOrderResult CalculateCost(List<ParcelDimensions> parcelOrder)
        {
            var result = new ParcelOrderResult();

            foreach (var parcelDimensions in parcelOrder)
            {
                var parcelResult = new ParcelResult
                {
                    ParcelDimensions = parcelDimensions
                };

                if (parcelDimensions.AreAllDimensionsWithin(10))
                {
                    parcelResult.ParcelCategory = ParcelCategory.Small;
                    parcelResult.Cost = SmallParcelCost;
                }
                else if (parcelDimensions.AreAllDimensionsWithin(50))
                {
                    parcelResult.ParcelCategory = ParcelCategory.Medium;
                    parcelResult.Cost = MediumParcelCost;
                }
                else if (parcelDimensions.AreAllDimensionsWithin(100))
                {
                    parcelResult.ParcelCategory = ParcelCategory.Large;
                    parcelResult.Cost = LargeParcelCost;
                }
                else
                {
                    parcelResult.ParcelCategory = ParcelCategory.ExtraLarge;
                    parcelResult.Cost = ExtraLargeParcelCost;
                }

                result.ParcelResults.Add(parcelResult);
            }

            return result;
        }
    }
}
