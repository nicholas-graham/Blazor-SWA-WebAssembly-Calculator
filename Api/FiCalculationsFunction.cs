using Api.Calculations;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class FiCalculationsFunction
    {
        private readonly ILogger<FiCalculationsFunction> _logger;

        public FiCalculationsFunction(ILogger<FiCalculationsFunction> logger)
        {
            _logger = logger;
        }

        [Function("Calculations")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            // Get the user inputs from the request body
            var userInputs = await req.ReadFromJsonAsync<UserInputs>();
            if (userInputs == null)
            {
                _logger.LogInformation("Inputs were null, returning early.");
                return new BadRequestObjectResult("Invalid request body.");
            }
            _logger.LogInformation("Recieved non-null inputs, calculations started.");


            // Calculate the retirement age
            var age = PredictedAgeCalculator.GetPredictedRetirementAge(userInputs);
            _logger.LogInformation("Calculations completed, predicted retirement {Age}", age);

            return new OkObjectResult(new CalculationResults { PredictedRetirementAge = age });
        }
    }
}
