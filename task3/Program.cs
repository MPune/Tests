using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace Task3
{
    class Program
    {
        class TestResults
        {
            public class TestResult
            {
                public int id { get; set; }
                public string value { get; set; }
            }
            public List<TestResult> values { get; set; }
        }

        [Serializable]
        class Tests
        {
            public class Test
            {
                public int id { get; set; }
                public string title { get; set; }
                public string value { get; set; }
                public List<Test> values { get; set; }
            }
            public List<Test> tests { get; set; }
        }
        
        static void SetValue(Tests.Test test, Dictionary<int, string> values)
        {
            if (values.ContainsKey(test.id))
                test.value = values[test.id];
            if (test.values is not null)
                test.values.ForEach(x => SetValue(x, values));
        }

        static public void Main(string[] args)
        {
            var valuesPath = args[0];
            var testsPath = args[1];
            var reportPath = args[2];

            string valuesFileData = File.ReadAllText(valuesPath);
            var valuesResults = JsonSerializer
                .Deserialize<TestResults>(valuesFileData)
                .values
                .ToDictionary(x => x.id, x => x.value);

            string testsFileData = File.ReadAllText(testsPath);
            var testsFromFile = JsonSerializer
                .Deserialize<Tests>(testsFileData);
            testsFromFile
                .tests
                .ForEach(x => SetValue(x, valuesResults));

            var options = new JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true };
            File.WriteAllText(reportPath, JsonSerializer.Serialize(testsFromFile, options));
        }
    }
}
