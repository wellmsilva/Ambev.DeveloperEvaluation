using Ambev.DeveloperEvaluation.Integration.Common;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration;

public class SalesControllerIntegrationTests : IClassFixture<AmbevWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

   
    public SalesControllerIntegrationTests(AmbevWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }
}
