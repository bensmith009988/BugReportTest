using BugReportTest.Shared.Models;

namespace BugReportTest.Client.Services
{
    /// <summary>
    /// Interface for the TestDataService
    /// </summary>
    public interface ITestDataService
    {
        /// <summary>
        /// The method to return test data
        /// </summary>
        /// <returns>
        /// List<TestData></TestData>
        /// </returns>
        Task<List<TestData>> GetTestDataAsync();
    }
}