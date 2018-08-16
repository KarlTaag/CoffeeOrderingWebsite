using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CoffeeOrderingWebsite.Models.ViewModels
{
    public class OrderHistoryViewModel : IDataPoint
    {
        public List<OrderHistory> OrderHistoryList { get; set; }

        public List<DataPoint> DataPoints { get; set; }

        public void CreateDataPoints()
        {
            DataPoints = new List<DataPoint>();

            var orderHistoryGroup = OrderHistoryList.GroupBy(x => x.DrinkName);

            foreach(var orderHistory in orderHistoryGroup)
            {
                DataPoints.Add(new DataPoint()
                {
                    Label = orderHistory.Key,
                    Value = orderHistory.Count()
                });
            }
        }

        public string SerializeDataPoints()
        {
            return JsonConvert.SerializeObject(DataPoints);
        }
    }
}