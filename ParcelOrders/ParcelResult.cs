namespace ParcelOrders.Services
{
    public class ParcelResult
    {
        public decimal Cost { get; internal set; }
        public ParcelCategory ParcelCategory { get; internal set; }
        public ParcelDimensions ParcelDimensions { get; init; }
    }
}
