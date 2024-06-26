using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IGetJobInfoTests
    {
        [Theory, AutoData]
        public async Task IGetJobInfo(JobInfoResponse expected, string jobID)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IGetJobInfo>();
            var result = await api.GetAsync(jobID);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}");
        }

        [Theory, AutoData]
        public async Task IGetJobInfo_ApiVersion(JobInfoResponse expected, string jobID)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IGetJobInfo>();
            var result = await api.GetAsync(jobID, CancellationToken.None, "v56.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v56.0/jobs/ingest/{jobID}");
        }
    }
}