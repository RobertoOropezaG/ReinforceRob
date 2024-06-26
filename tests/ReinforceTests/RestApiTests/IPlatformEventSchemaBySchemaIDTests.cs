using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IPlatformEventSchemaBySchemaIDTests
    {
        [Theory, AutoData]
        public async Task IPlatformEventSchemaBySchemaID(string expected, string schemaId)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IPlatformEventSchemaBySchemaID>();
            var result = await api.GetAsync<string>(schemaId);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/event/eventSchema/{schemaId}");
        }

        [Theory, AutoData]
        public async Task IPlatformEventSchemaBySchemaID_PayloadFormat(string expected, string schemaId, string payloadFormat)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IPlatformEventSchemaBySchemaID>();
            var result = await api.GetAsync<string>(schemaId, payloadFormat, CancellationToken.None, "v56.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v56.0/event/eventSchema/{schemaId}?payloadFormat={payloadFormat}");
        }
    }
}