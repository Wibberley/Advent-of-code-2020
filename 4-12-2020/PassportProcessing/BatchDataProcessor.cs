using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassportProcessing
{
    public class BatchDataProcessor
    {
        public List<List<string>> ProcessData(string data)
        {
            var batchData = new List<List<string>>(8);

            var everyProperty = data
                .Trim()
                .Split(Environment.NewLine)
                .SelectMany(x => x.Split(' '))
                .ToList();

            var propertyCollection = new List<string>();

            foreach (var property in everyProperty)
            {
                if (!string.IsNullOrWhiteSpace(property))
                {
                    propertyCollection.Add(property);
                }
                else
                {
                    batchData.Add(propertyCollection);
                    propertyCollection = new List<string>(8);
                }
            }

            if (propertyCollection.Count > 0)
                batchData.Add(propertyCollection);

            return batchData;
        }
    }
}
