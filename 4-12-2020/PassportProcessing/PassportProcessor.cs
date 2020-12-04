using System;
using Utilities;

namespace PassportProcessing
{
    public class PassportProcessor
    {
        private readonly BatchDataProcessor _batchDataProcessor;
        private readonly IPassportValidator _passportValidator;

        public PassportProcessor(
            BatchDataProcessor batchDataProcessor,
            IPassportValidator passportValidator)
        {
            _batchDataProcessor = batchDataProcessor;
            _passportValidator = passportValidator;
        }

        public int ProcessBatchFile(string fileName)
        {
            int validPassports = 0;

            var fileContents = FileReader.ReadFile(fileName);
            var processedData = _batchDataProcessor.ProcessData(fileContents);

            foreach (var data in processedData)
            {
                var passport = new PassportBuilder()
                    .AddData(data)
                    .GetPassport();

                if (_passportValidator.IsPassportValid(passport))
                    validPassports++;
            }

            return validPassports;
        }
    }
}
