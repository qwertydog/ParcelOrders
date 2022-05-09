namespace ParcelOrders.Services
{
    public class ParcelDimensions
    {
        public decimal HeightInCm { get; }
        public decimal WeightInCm { get; }
        public decimal DepthInCm { get; }

        public ParcelDimensions(decimal heightInCm, decimal weightInCm, decimal depthInCm)
        {
            HeightInCm = heightInCm;
            WeightInCm = weightInCm;
            DepthInCm = depthInCm;
        }

        public bool AreAllDimensionsWithin(decimal sizeInCm)
            => HeightInCm < sizeInCm
            && WeightInCm < sizeInCm
            && DepthInCm < sizeInCm;
    }
}
