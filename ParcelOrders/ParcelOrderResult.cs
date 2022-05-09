using System.Collections.Generic;
using System.Linq;

namespace ParcelOrders.Services
{
    public class ParcelOrderResult
    {
        public decimal TotalCost => ParcelResults.Sum(x => x.Cost);

        public List<ParcelResult> ParcelResults { get; } = new List<ParcelResult>();
    }
}
