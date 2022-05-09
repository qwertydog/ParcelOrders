using System.Collections.Generic;

namespace ParcelOrders.Services
{
    public class ParcelOrder
    {
        public List<ParcelDimensions> ParcelsDimensions { get; }
        public bool IsSpeedyShipping { get; }

        public ParcelOrder(List<ParcelDimensions> parcelsDimensions) : this(parcelsDimensions, false) { }

        public ParcelOrder(List<ParcelDimensions> parcelsDimensions, bool isSpeedyShipping)
        {
            ParcelsDimensions = parcelsDimensions;
            IsSpeedyShipping = isSpeedyShipping;
        }
    }
}
