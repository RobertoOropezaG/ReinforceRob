using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectDescribeTests
    {
        [Theory, AutoData]
        public async Task ISObjectDescribe(string sObjectName)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(null);
            var api = handler.SetupApi<ISObjectDescribe>();
            await api.GetAsync(sObjectName, CancellationToken.None, "v56.0");
            handler.ConfirmPath($"/services/data/v56.0/sobjects/{sObjectName}/describe");
        }
    }
}