using System.Collections.Generic;

namespace CoffeeOrderingWebsite.Models.ViewModels
{
    public interface IDataPoint
    {
        List<DataPoint> DataPoints { get; set; }

        void CreateDataPoints();

        string SerializeDataPoints();
    }
}
