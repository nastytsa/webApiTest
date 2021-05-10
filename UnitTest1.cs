using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Json;
using System.Net;
using NUnit.Framework;
using RA;

namespace weApiTest
{
    [TestClass]
    public class UnitTest1
    {
        private string ACCESS_TOKEN = "k22xIkOEk4UAAAAAAAAAAQGnV7_UHGw6QPS6c49018sc7SeM3fSdgjytRrq0HVff";

        [TestMethod]
        public void A_uploadTest()
        {

            JsonObject json = new JsonObject();
            json.Add("mode", "add");
            json.Add("autorename", true);
            json.Add("path", "/testing.json");

            JsonObject jsonFile = new JsonObject();
            jsonFile.Add("message", "Hello");

            new RestAssured()
                .Given()
                    .Header("Dropbox-API-Arg", json.ToString())
                    .Header("Content-Type", "application/json")
                    .Header("Authorization", "Bearer " + ACCESS_TOKEN)
                    .Body(jsonFile.ToString())
                .When()
                    .Post("https://content.dropboxapi.com/2/files/upload")
                .Then()
                    .TestStatus("test a", x => x == (int)HttpStatusCode.OK)
                    .Assert("test a");
        }
        [TestMethod]
        public void B_getMetadataTest()
        {

            JsonObject json = new JsonObject();
            json.Add("path", "/testing.txt");

            new RestAssured()
                .Given()
                .Header("Authorization", "Bearer " + ACCESS_TOKEN)
                .Header("Content-Type", "application/json")
                .Body(json.ToString())
                .When()
                .Post("https://api.dropboxapi.com/2/files/get_metadata")
                .Then()
                .TestStatus("test a", x => x == (int)HttpStatusCode.OK)
                .Assert("test a");
        }

        [TestMethod]
        public void C_deleteTest()
        {

            JsonObject json = new JsonObject();
            json.Add("path", "/testing.txt");

            new RestAssured()
                .Given()
                    .Header("Authorization", "Bearer " + ACCESS_TOKEN)
                    .Header("Content-Type", "application/json")
                    .Body(json.ToString())
                .When()
                    .Post("https://api.dropboxapi.com/2/files/delete_v2")
                .Then()
                    .TestStatus("test a", x => x == (int)HttpStatusCode.OK)
                    .Assert("test a");
        }
    }
}
