using FlightDelayPrediction.DataModels;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using static Microsoft.ML.Transforms.MissingValueReplacingEstimator;

namespace FlightDelayPrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<FlightDelayData>("./FlightData.csv", hasHeader: true, separatorChar: ',', allowQuoting: true);

            var dataPrepPipeline = context.Transforms.SelectColumns("MONTH", "DAY_OF_MONTH", "DAY_OF_WEEK", "ORIGIN", "DEST", "CRS_DEP_TIME", "ARR_DEL15")
                .Append(context.Transforms.Categorical.OneHotEncoding("OriginEncoded", "ORIGIN"))
                .Append(context.Transforms.Categorical.OneHotEncoding("DestEncoded", "DEST"))
                .Append(context.Transforms.DropColumns("ORIGIN", "DEST"))
                .Append(context.Transforms.Concatenate("Features", "MONTH", "DAY_OF_MONTH", "DAY_OF_WEEK", "CRS_DEP_TIME", "OriginEncoded", "DestEncoded"))
                .Append(context.Transforms.CopyColumns("Label", "ARR_DEL15"))
                .Append(context.Transforms.Conversion.ConvertType("Label", "Label", DataKind.Boolean));

            data = dataPrepPipeline.Fit(data).Transform(data);

            ConsoleHelper.PeekData(data);

            var fillNaTransform = context.Transforms.ReplaceMissingValues("ARR_DEL15Replaced", "ARR_DEL15", ReplacementMode.DefaultValue);
            data = fillNaTransform.Fit(data).Transform(data);

            var testTrainData = context.Data.TrainTestSplit(data, testFraction: 0.2);

            var trainer = context.BinaryClassification.Trainers.SdcaLogisticRegression();
            var model = trainer.Fit(testTrainData.TrainSet);

            var predictions = model.Transform(testTrainData.TestSet);

            var metrics = context.BinaryClassification.Evaluate(predictions);

            Console.WriteLine($"AUC - {metrics.AreaUnderRocCurve}");

            Console.ReadLine();
        }
    }
}
