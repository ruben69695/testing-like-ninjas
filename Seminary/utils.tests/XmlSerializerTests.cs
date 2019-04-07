using System;
using NUnit.Framework;
using utils;

namespace Tests
{
    [TestFixture]
    public class XmlSerializerTests
    {
        private XmlSerializer _xmlSerializer;

        [SetUp]
        public void Setup()
        {
            _xmlSerializer = new XmlSerializer();
        }

        [Test]
        public void Serialize_SerializeAnObject_ShouldSerializeItToXmlFormatString()
        {
            string expectedResult = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                "<User xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                    "<Name>Jack</Name>" +
                    "<LastName>Stilson</LastName>" +
                    "<Age>28</Age>" +
                    "<Email>jack23@test.com</Email>" +
                "</User>";
                
            var user = new User { 
                Name = "Jack", 
                LastName = "Stilson", 
                Age = 28, 
                Email = "jack23@test.com" 
            };

            string result = _xmlSerializer.Serialize(user);

            Assert.AreEqual(result, expectedResult);
        }
    }
}