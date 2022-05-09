namespace ParcelOrders.Services
{
    public abstract class OrderItem
    {
        public abstract decimal Cost { get; }
        public abstract OrderItemCategory OrderItemCategory { get; }
    }

    public abstract class ParcelItem : OrderItem
    {
        private const decimal OverweightPerKgCost = 2;

        public abstract decimal WeightLimitInKg { get; }

        internal static ParcelItem Create(ParcelDimensions parcelDimensions)
        {
            if (parcelDimensions.AreAllDimensionsWithin(10))
                return new SmallParcel();
            else if (parcelDimensions.AreAllDimensionsWithin(50))
                return new MediumParcel();
            else if (parcelDimensions.AreAllDimensionsWithin(100))
                return new LargeParcel();
            else
                return new ExtraLargeParcel();
        }
    }

    internal class SmallParcel : ParcelItem
    {
        public override decimal Cost => 3;
        public override OrderItemCategory OrderItemCategory => OrderItemCategory.SmallParcel;
        public override decimal WeightLimitInKg => 1;
    }

    internal class MediumParcel : ParcelItem
    {
        public override decimal Cost => 8;
        public override OrderItemCategory OrderItemCategory => OrderItemCategory.MediumParcel;
        public override decimal WeightLimitInKg => 3;
    }

    internal class LargeParcel : ParcelItem
    {
        public override decimal Cost => 15;
        public override OrderItemCategory OrderItemCategory => OrderItemCategory.LargeParcel;
        public override decimal WeightLimitInKg => 6;
    }

    internal class ExtraLargeParcel : ParcelItem
    {
        public override decimal Cost => 25;
        public override OrderItemCategory OrderItemCategory => OrderItemCategory.ExtraLargeParcel;
        public override decimal WeightLimitInKg => 10;
    }

    public class SpeedyShipping : OrderItem
    {
        public override decimal Cost { get; }
        public override OrderItemCategory OrderItemCategory => OrderItemCategory.SpeedyShipping;

        internal SpeedyShipping(decimal parcelCosts)
        {
            Cost = parcelCosts;
        }
    }
}
