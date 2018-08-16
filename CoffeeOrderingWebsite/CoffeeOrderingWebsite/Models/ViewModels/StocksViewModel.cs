using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeOrderingWebsite.Models.ViewModels
{
    public class StocksViewModel : IDataPoint
    {
        public List<Stock> AvailableStocks { get; set; }

        public List<DataPoint> DataPoints { get; set; }

        public void CreateDataPoints()
        {
            DataPoints = new List<DataPoint>();

            var stockHistoryGroup = AvailableStocks.GroupBy(x => x.Name);

            foreach (var stockHistory in stockHistoryGroup)
            {
                DataPoints.Add(new DataPoint()
                {
                    Label = stockHistory.Key,
                    Value = stockHistory.Sum(x => x.RemainingUnits)/15m
                });
            }
        }

        public string SerializeDataPoints()
        {
            return JsonConvert.SerializeObject(DataPoints);
        }
    }
}