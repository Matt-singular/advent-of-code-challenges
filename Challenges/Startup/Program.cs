using Challenges.Startup;
using Microsoft.Extensions.DependencyInjection;

// Dependency Injection
var serviceProvider = new ServiceCollection()
  .AddChallengeServicesFor2023()
  .BuildServiceProvider();

// Startup messag
Console.WriteLine("Run the unit test cases to test the implemented solutions against the answers");
Console.ReadLine();