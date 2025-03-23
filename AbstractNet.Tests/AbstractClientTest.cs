namespace AbstractNet.Tests
{
    [TestClass]
    public sealed class AbstractClientTest
    {
        AbstractClient client;
        const string ApiKey = ""; // Add api key here!

        [TestInitialize]
        public void SetUp()
        {
            client = new AbstractClient(ApiKey);
        }

        [TestMethod]
        public void TestProcessImageFromUrl_ValidUrl()
        {
            AbstractRequest request = new AbstractRequest()
            {
                ApiKey = ApiKey,
                Url = "https://www.iconsdb.com/icons/preview/black/square-xxl.png",
                Quality = 65
            };
            AbstractResponse response = client.ProcessImageFromUrl(request).Result;
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Url));
            Assert.IsTrue(response.BytesSaved > 0);
        }
    }
}
