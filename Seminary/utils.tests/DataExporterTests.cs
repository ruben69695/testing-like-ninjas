using NUnit.Framework;
using NSubstitute;
using utils;

namespace Tests
{
    [TestFixture]
    public class DataExporterTests
    {
        private DataExporter _dataExporter;
        private ISerializer _serializer;
        private IWritable _writableDestination;

        [SetUp]
        public void Setup()
        {
            _serializer = Substitute.For<ISerializer>();
            _writableDestination = Substitute.For<IWritable>();
            _dataExporter = new DataExporter(_serializer);
        }

        [Test]
        public void Export_MethodCall_ShouldReturnTrue()
        {
            // Simulamos la serialización de los datos
            string serializerDataSimulation = "Estos son los datos serializados, me da igual el formato que sea";
            _serializer.Serialize(Arg.Any<User>()).Returns(serializerDataSimulation);

            // Simulamos la escritura de los datos en un destino
            _writableDestination.Write(serializerDataSimulation).Returns(true);

            // Actuamos sobre el método que queremos probar
            var result = _dataExporter.Export(new User(), _writableDestination);

            // Afirmamos que la prueba pase
            Assert.That(result, Is.True);
        }
    }
}