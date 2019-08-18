using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDelayPrediction
{
    public static class ConsoleHelper
    {
        public static void PeekData(IDataView dataView, int numberOfRowsToDisplay = 5)
        {
            var preview = dataView.Preview(maxRows: numberOfRowsToDisplay);

            Console.WriteLine("Sample of data:");

            foreach (var row in preview.RowView)
            {
                string rowData = "Row = ";
                foreach (var value in row.Values)
                {
                    rowData += $"{value.Key} - {value.Value} ";
                }

                Console.Write(rowData + Environment.NewLine);
            }
        }
    }
}
