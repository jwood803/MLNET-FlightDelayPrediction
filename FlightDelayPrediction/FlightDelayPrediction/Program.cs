using FlightDelayPrediction.DataModels;
using Microsoft.ML;
using System;

namespace FlightDelayPrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<FlightDelayData>("./FlightData.csv", hasHeader: true, separatorChar: ',');

            var keepColumnsTransform = context.Transforms.SelectColumns(
                "MONTH", "DAY_OF_MONTH", "DAY_OF_WEEK", "ORIGIN", "DEST", "CRS_DEP_TIME", "ARR_DEL15");

            var newData = keepColumnsTransform.Fit(data).Transform(data);

            ConsoleHelper.PeekData(newData);
        }
    }
}
