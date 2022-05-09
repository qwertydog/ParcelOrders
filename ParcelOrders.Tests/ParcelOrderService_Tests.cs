using Xunit;
using System.Collections.Generic;
using ParcelOrders.Services;
using System.Linq;

namespace ParcelOrders.Tests
{
    public class ParcelOrderService_Tests
    {
        [Fact]
        public void ParcelOrderService_SingleOrderAllDimensionsLessThan10_ReturnSmallParcel()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(5m, 7m, 1m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 3);
            Assert.True(orderResult.ParcelResults.Single().ParcelCategory == ParcelCategory.Small);
            Assert.True(orderResult.ParcelResults.Single().Cost == 3);
        }

        [Fact]
        public void ParcelOrderService_MultipleOrdersAllDimensionsLessThan10_ReturnSmallParcels()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(5m, 7m, 1m),
                new ParcelDimensions(8m, 1m, 9m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 6);
            Assert.True(orderResult.ParcelResults.All(x => x.ParcelCategory == ParcelCategory.Small));
            Assert.True(orderResult.ParcelResults.All(x => x.Cost == 3));
        }

        [Fact]
        public void ParcelOrderService_SingleOrderAllDimensionsLessThan50_ReturnMediumParcel()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(25m, 17m, 1m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 8);
            Assert.True(orderResult.ParcelResults.Single().ParcelCategory == ParcelCategory.Medium);
            Assert.True(orderResult.ParcelResults.Single().Cost == 8);
        }

        [Fact]
        public void ParcelOrderService_MultipleOrdersAllDimensionsLessThan50_ReturnMediumParcels()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(25m, 17m, 1m),
                new ParcelDimensions(44m, 12m, 7m),
                new ParcelDimensions(17m, 6m, 7m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 24);
            Assert.True(orderResult.ParcelResults.All(x => x.ParcelCategory == ParcelCategory.Medium));
            Assert.True(orderResult.ParcelResults.All(x => x.Cost == 8));
        }

        [Fact]
        public void ParcelOrderService_SingleOrderAllDimensionsLessThan100_ReturnLargeParcel()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(25m, 17m, 96m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 15);
            Assert.True(orderResult.ParcelResults.Single().ParcelCategory == ParcelCategory.Large);
            Assert.True(orderResult.ParcelResults.Single().Cost == 15);
        }

        [Fact]
        public void ParcelOrderService_MultipleOrdersAllDimensionsLessThan100_ReturnLargeParcels()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(75m, 17m, 1m),
                new ParcelDimensions(80m, 99m, 99m),
                new ParcelDimensions(17m, 57m, 85m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 45);
            Assert.True(orderResult.ParcelResults.All(x => x.ParcelCategory == ParcelCategory.Large));
            Assert.True(orderResult.ParcelResults.All(x => x.Cost == 15));
        }

        [Fact]
        public void ParcelOrderService_SingleOrderAnyDimensionLargerThan100_ReturnExtraLargeParcel()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(500m, 17m, 96m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 25);
            Assert.True(orderResult.ParcelResults.Single().ParcelCategory == ParcelCategory.ExtraLarge);
            Assert.True(orderResult.ParcelResults.Single().Cost == 25);
        }

        [Fact]
        public void ParcelOrderService_MultipleOrdersAnyDimensionLargerThan100_ReturnExtraLargeParcels()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(75m, 537m, 1m),
                new ParcelDimensions(80m, 99m, 476m)
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 50);
            Assert.True(orderResult.ParcelResults.All(x => x.ParcelCategory == ParcelCategory.ExtraLarge));
            Assert.True(orderResult.ParcelResults.All(x => x.Cost == 25));
        }

        [Fact]
        public void ParcelOrderService_MultipleOrdersMultipleDimension_ReturnMultipleParcelCategories()
        {
            var parcelOrder = new List<ParcelDimensions>
            {
                new ParcelDimensions(1m, 5m, 4m),
                new ParcelDimensions(25m, 18m, 6m),
                new ParcelDimensions(5m, 99m, 75m),
                new ParcelDimensions(80m, 99m, 476m)
            };

            var expectedCategories = new[]
            {
                ParcelCategory.Small,
                ParcelCategory.Medium,
                ParcelCategory.Large,
                ParcelCategory.ExtraLarge
            };

            var orderService = new ParcelOrderService();
            var orderResult = orderService.CalculateCost(parcelOrder);

            Assert.True(orderResult.TotalCost == 51);
            Assert.True(orderResult.ParcelResults.All(x => expectedCategories.Contains(x.ParcelCategory)));
        }
    }
}