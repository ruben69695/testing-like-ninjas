using System.Net;
using MagicDarkLibraries.Installer;
using NUnit.Framework;
using NSubstitute;

namespace TestingLikeNinjas.UnitTests.Installer
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private IFileDownloader _fileDownloader;
        private string _setupDestination;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = Substitute.For<IFileDownloader>();
            _setupDestination = "/home/ruben/downloads/setup.sh";
            _installerHelper = new InstallerHelper(_fileDownloader, _setupDestination);
        }

        [Test]
        public void DownloadInstaller_MethodCallCorrectDownload_ShouldDownloadInstaller()
        {
            bool operationResult = _installerHelper.DownloadInstaller("ruben", "setup.sh");
            
            Assert.That(operationResult, Is.True);
        }

        [Test]
        public void DownloadInstaller_MethodCallIncorrectDownload_ShouldThrowWebException()
        {
            // Mock/Fake result, throw WebException, for voids and non-voids:
            _fileDownloader
                    .When(x => x.DownloadFile("https://example.com/paco/setup.sh", _setupDestination))
                    .Do(x => throw new WebException());
            
            bool operationResult = _installerHelper.DownloadInstaller("paco", "setup.sh");
            
            Assert.That(operationResult, Is.False);
        }

        [Test]
        public void DownloadInstaller_PassEmptyCostumerName_ShouldThrowArgumentNullException()
        {
            Assert.That(() =>
            {
                _installerHelper.DownloadInstaller(string.Empty, "setup.sh");
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void DownloadInstaller_PassEmptyFileName_ShouldThrowArgumentNullException()
        {
            Assert.That(() =>
            {
                _installerHelper.DownloadInstaller("hernando", string.Empty);
            }, Throws.ArgumentNullException);
        }
        
    }
}