using NUnit.Framework;
using utils;

namespace Tests
{
    [TestFixture]
    public class JsonSerializerTests
    {
        private JsonSerializer _jsonSerializer;

        [SetUp]
        public void Setup()
        {
            _jsonSerializer = new JsonSerializer();
        }

        [Test]
        public void Serialize_SerializeAnObject_ShouldSerializeItToJsonFormatString()
        {
            string expectedResult = "{\"Name\":\"Jack\",\"LastName\":\"Stilson\",\"Age\":28,\"Email\":\"jack23@test.com\"}";
            var user = new User { 
                Name = "Jack", 
                LastName = "Stilson", 
                Age = 28, 
                Email = "jack23@test.com" 
            };

            string result = _jsonSerializer.Serialize(user);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}