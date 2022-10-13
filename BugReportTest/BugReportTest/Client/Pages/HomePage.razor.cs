using BugReportTest.Client.Services;
using BugReportTest.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BugReportTest.Client.Pages
{
    public partial class HomePage
    {
        [Inject]
        private ITestDataService testDataService { get; set; }

        private List<TestData> ToShow { get; set; }

        /// <summary>
        /// The method to return test data
        /// </summary>
        /// <returns>
        /// <returns>
        /// List<TestData>
        /// </returns>
        public async Task GetTestData()
        {
            var response = await testDataService.GetTestDataAsync();

            ToShow = response;
        }
    }
}