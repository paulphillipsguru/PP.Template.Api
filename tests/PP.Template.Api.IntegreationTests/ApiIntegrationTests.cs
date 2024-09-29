using Microsoft.AspNetCore.Mvc.Testing;
using PP.Template.Api.Models.Example;
using System.Net.Http.Json;

namespace PP.Template.Api.IntegrationTests;

public class ApiIntegrationTests(WebApplicationFactory<IPPTemplateApiMarker> factory) : CustomFixture
{    
    [Fact]
    public async Task GetExample_Return_SingleRecord()
    {
        //Act                
        var model = new NewExampleModel { Name  = "Test" };
        var client = factory.CreateClient();

        var result = await client.PostAsJsonAsync("/Example", model);
        result.EnsureSuccessStatusCode();
        var contents =  await result.Content.ReadAsStringAsync();
        
        Assert.NotNull(contents);
        Assert.NotNull(result);

        Assert.Equal("1", contents);
        

    }
}
