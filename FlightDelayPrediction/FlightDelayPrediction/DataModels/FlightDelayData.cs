using Microsoft.ML.Data;

namespace FlightDelayPrediction.DataModels
{
    public class FlightDelayData
    {
        [LoadColumn(0), ColumnName("YEAR")]
        public float Year { get; set; }

        [LoadColumn(1), ColumnName("QUARTER")]
        public float Quarter { get; set; }

        [LoadColumn(2), ColumnName("MONTH")]
        public float Month { get; set; }

        [LoadColumn(3), ColumnName("DAY_OF_MONTH")]
        public float DayOfMonth { get; set; }

        [LoadColumn(4), ColumnName("DAY_OF_WEEK")]
        public float DayOfWeek { get; set; }

        [LoadColumn(5), ColumnName("UNIQUE_CARRIER")]
        public string UniqueCarrier { get; set; }

        [LoadColumn(6), ColumnName("TAIL_NUM")]
        public string TailNumber{ get; set; }

        [LoadColumn(7), ColumnName("FL_NUM")]
        public float FlightNumber { get; set; }

        [LoadColumn(8), ColumnName("ORIGIN_AIRPORT_ID")]
        public float OriginAirportId { get; set; }

        [LoadColumn(9), ColumnName("ORIGIN")]
        public string OriginAirport { get; set; }

        [LoadColumn(10), ColumnName("DEST_AIRPORT_ID")]
        public float DestinatoinAirportId { get; set; }

        [LoadColumn(11), ColumnName("DEST")]
        public string DestinatoinAirport { get; set; }

        [LoadColumn(12), ColumnName("CRS_DEP_TIME")]
        public float CrsDepartTime { get; set; }

        [LoadColumn(13), ColumnName("DEP_TIME")]
        public float DepartTime { get; set; }

        [LoadColumn(14), ColumnName("DEP_DELAY")]
        public float DepartDelay { get; set; }

        [LoadColumn(15), ColumnName("DEP_DEL15")]
        public float IsDepartDelayed15Minutes { get; set; }

        [LoadColumn(16), ColumnName("CRS_ARR_TIME")]
        public float CrsArrivalTime { get; set; }

        [LoadColumn(17), ColumnName("ARR_TIME")]
        public float ArrivalTime { get; set; }

        [LoadColumn(18), ColumnName("ARR_DELAY")]
        public float ArrivalDelay { get; set; }

        [LoadColumn(19), ColumnName("ARR_DEL15")]
        public float IsArrivalDelayed15Minutes { get; set; }

        [LoadColumn(20), ColumnName("CANCELLED")]
        public float IsFlightCancelled { get; set; }

        [LoadColumn(21), ColumnName("DIVERTED")]
        public float IsFlightDiverted { get; set; }

        [LoadColumn(22), ColumnName("CRS_ELAPSED_TIME")]
        public float CrsElapsedTime { get; set; }

        [LoadColumn(23), ColumnName("ACTUAL_ELAPSED_TIME")]
        public float FlightElapsedTime { get; set; }

        [LoadColumn(24), ColumnName("DISTANCE")]
        public float FlightDistance { get; set; }
    }
}
