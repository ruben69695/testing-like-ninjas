using NUnit.Framework;
using NSubstitute;
using utils;

namespace Tests
{
    [TestFixture]
    public class FileSerializerTests
    {
        private FileSerializer _fileSerializer;
        private ISerializer _serializerMock;

        [SetUp]
        public void Setup()
        {
            _serializerMock = Substitute.For<ISerializer>();
            _fileSerializer = new FileSerializer(_serializerMock);
        }

        [Test]
        public void SerializeToFile_MethodCall_ShouldCreateFileWithContent()
        {
            // Simulamos el resultado que internamente nos generará la llamada a la función Serialize
            _serializerMock.Serialize(Arg.Any<User>()).Returns("Esto es el resultado que simulo, me da igual si es json, xml, chino o catalán, no estoy testeando la clase que lo hace ahora mismo");

            var result = _fileSerializer.SerializeToFile(new User(), "test.txt");

            Assert.That(result, Is.True);
        }
    }
}