using BugReportTest.Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BugReportTest.Client.Services
{
    // This is the file where the bug has been found. Scroll to find comments and read instructions.
    public class TestDataService : ITestDataService
    {
        private readonly HttpClient client;

        public TestDataService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<TestData>> GetTestDataAsync()
        {
            Random rn = new();
            int number = rn.Next(1, 100);

            if (number < 999)
            {
                List<TestData> toReturn = new List<TestData>();

                HttpResponseMessage response = await client.GetAsync("https://localhost:7253/api/test/data");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (responseString != null)
                    {
                        toReturn = JsonConvert.DeserializeObject<List<TestData>>(responseString);

                        try
                        {
                            // If toReturn was truly null, this should throw a Null Reference Exception
                            // Add a breakpoint on line 37 to see if one is thrown.
                            toReturn.Add(new TestData
                            {
                                Id = 999999,
                                Name = "Test for Null Reference Exception",
                                Description = "This item is added to the list in order to test for a null reference exception"
                            });
                        }
                        catch
                        {

                        }
                    }
                }

                // Uncomment this line of code on the SECOND time you run the program to see the output
                // Open up the output window and show output from: "Debug"
                //Debug.WriteLine(toReturn?.ToString());

                // set breakpoint on line 59
                // While debugging, add "toReturn" to watch list. You will see the object type is not picked up
                // Hover over toReturn to bring up intellisense value. You will see that it is null.
                // Press continue to step through, and you will see the data returned to the UI
                return toReturn;
            }
            else
            {
                // If you change the name of toReturn in THIS code block, or so that both names no longer match, the bug goes away completely.
                List<TestData> toReturn = new List<TestData>()
                {
                    new TestData()
                    {
                        Id = rn.Next(1, 100),
                        Name = "DefaultData1",
                        Description = "Default data"
                    },
                    new TestData()
                    {
                        Id = rn.Next(1, 100),
                        Name = "DefaultData1",
                        Description = "Default data"
                    },
                    new TestData()
                    {
                        Id = rn.Next(1, 100),
                        Name = "DefaultData1",
                        Description = "Default data"
                    }
                };

                return toReturn;
            }
        }
    }
}