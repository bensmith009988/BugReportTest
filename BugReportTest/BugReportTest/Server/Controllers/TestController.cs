using Microsoft.AspNetCore.Mvc;
using BugReportTest.Shared.Models;
using System;

namespace BugReportTest.Server.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet("data")]
        public async Task<ActionResult<List<TestData>>> GetData()
        {
            List<TestData> data = new List<TestData>();
            Random rn = new Random();
            int loopSize = rn.Next(0, 10);

            for(int i = 1; i <= loopSize + 1; i++)
            {
                data.Add(new TestData()
                {
                    Id = rn.Next(1, 100),
                    Name = $"Test{i}",
                    Description = RandomString(rn.Next(25, 75))
                });
            }

            return data; 
        }

        private static string RandomString(int length)
        {
            Random rn = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rn.Next(s.Length)]).ToArray());
        }
    }
}