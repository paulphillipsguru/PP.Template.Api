using Microsoft.AspNetCore.Mvc.Testing;
using PP.Template.Api.Models.Example;
using System.Net.Http.Json;

namespace PP.Template.Api.IntegrationTests;

public class ApiIntegrationTests(WebApplicationFactory<IPPTemplateApiMarker> factory) : CustomAppFactory
{
    
    [Fact]
    public async Task GetExample_Return_SingleRecord()
    {
        //Act
        
        var client = factory.CreateClient();

        var model = new NewExampleModel { Name  = "Test" };

        var result = await client.PostAsJsonAsync("/Example", model);
        
        Assert.NotNull(result);

    }
}
