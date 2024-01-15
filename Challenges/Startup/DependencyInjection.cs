namespace Challenges.Startup;

using Challenges.Helpers;
using Challenges.Year2023.Day1;
using Challenges.Year2023.Day2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class DependencyInjection
{
  public static ServiceCollection AddChallengeServicesFor2023(this ServiceCollection serviceCollection)
  {
    // Add the Helper and extension services services
    serviceCollection.TryAddSingleton<IFileHelpers, FileHelpers>();

    // Add the Challenge services
    serviceCollection.TryAddScoped<IDayOneSolution, DayOneSolution>();
    serviceCollection.TryAddScoped<IDayTwoSolution, DayTwoSolution>();

    return serviceCollection;
  }
}