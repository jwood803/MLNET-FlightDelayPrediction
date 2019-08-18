using Microsoft.ML.Data;

namespace FlightDelayPrediction.DataModels
{
    public class FlightDelayPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Score { get; set; }
    }
}
