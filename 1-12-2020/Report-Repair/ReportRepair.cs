using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Report_Repair
{
    public class ReportRepair
    {
        private const long TARGET = 2020;
        private readonly RepairReportFinder _finder;

        public ReportRepair()
        {
            _finder = new RepairReportFinder(TARGET);
        }

        public long GetTotal(IEnumerable<string> inputs, int depth)
        {
            var repairReportCalculators = _finder.GetCalculators(inputs);

            var reportCalculator = repairReportCalculators.FirstOrDefault(x => x.NumberCount == depth);

            if (reportCalculator == null)
            {
                return 0;
            }

            return reportCalculator.GetResult();
        }
    }

    public class RepairReportFinder
    {
        private readonly long _target;

        public RepairReportFinder(long target)
        {
            _target = target;
        }

        public List<RepairReportCalculator> GetCalculators(IEnumerable<string> inputs)
        {
            // foreach item we need to add the next if its greater than 2020 go to the one after and so on
            // if its under 2020 we need to start again and add the first value to that, excluding the 2 values you have added so far

            // enumerate and store in a collection
            var collection = ValidateData(inputs);

            // create a collection of longs foreach entry in the collection 
            var result = new List<RepairReportCalculator>();

            foreach (var item in collection)
            {
                var currentCollection = collection.ToList();
                currentCollection.RemoveAt(0);

                var calculators = Recursive(new RepairReportCalculator(_target, item),
                                            currentCollection,
                                            null);

                result.AddRange(calculators);
            }

            return result;
        }

        private List<RepairReportCalculator> Recursive(RepairReportCalculator calculator,
                                                       List<long> collection,
                                                       List<RepairReportCalculator> calculators)
        {
            // grab a copy of the original collection
            var originalCollection = calculator.Numbers.ToList();

            calculators = calculators ?? new List<RepairReportCalculator>();

            var collection2 = collection.ToList();

            foreach (var item in collection.ToList())
            {
                // remove this item so it cant be added again
                collection2.Remove(item);

                // create a new calculator with the original collection
                calculator = new RepairReportCalculator(_target, calculator.InitialNumber)
                {
                    Numbers = originalCollection.ToList()
                };

                // if this is over the target skip
                if (calculator.Total() + item > _target)
                    continue;

                // add the value to the calculator
                calculator.Add(item);

                // if we are equal to the target then lets add this calculator 
                // and go to the next value 
                if (calculator.EqualsTarget)
                {
                    calculators.Add(calculator);
                    continue;
                }

                // lets go though all of the collection again, but without the one we just added
                Recursive(calculator, collection2, calculators);
            }

            return calculators;
        }

        private List<long> ValidateData(IEnumerable<string> inputs)
        {
            return inputs.Select(x =>
                {
                    if (long.TryParse(x, out long result))
                        return result;

                    return 0;
                })
                .Distinct()
                .ToList();
        }
    }

    public class RepairReportCalculator
    {
        private readonly long _target;

        public RepairReportCalculator(long target, long initialNumber) : this(target)
        {
            InitialNumber = initialNumber;
            Numbers = new List<long>() { initialNumber };
        }

        public RepairReportCalculator(long target)
        {
            _target = target;
            Numbers = new List<long>();
        }

        public long InitialNumber { get; }

        public int NumberCount => Numbers.Count;

        public bool EqualsTarget => Numbers.Sum() == _target;

        public IList<long> Numbers { get; set; }

        public void Add(long number)
        {
            Numbers.Add(number);
        }

        public long Total()
        {
            return Numbers.Sum();
        }

        public long GetResult()
        {
            long result = 1;
            foreach (var value in Numbers)
            {
                result = result * value;
            }
            return result;
        }
    }
}
