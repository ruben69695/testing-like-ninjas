using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using utils;

namespace Tests
{
    public class JsonDataExportationTests
    {
        private const string FILEPATH = "json_data_export_test.json";

        private DataExporter _dataExporter;
        private ISerializer _serializer;
        private IWritable _writableDestination;

        [SetUp]
        public void Setup()
        {
            _writableDestination = new FileWriterHelper(FILEPATH);
            _serializer = new JsonSerializer();
            _dataExporter = new DataExporter(_serializer);
        }

        [Test]
        public void ExportUserDataIntoJsonFormatFile()
        {
            string expectedDataResult = @"{""Name"":""Jack"",""LastName"":""Stilson"",""Age"":28,""Email"":""jack23@test.com""}" + Environment.NewLine;
            var user = new User { 
                Name = "Jack", 
                LastName = "Stilson", 
                Age = 28, 
                Email = "jack23@test.com" 
            };

            _dataExporter.Export(user, _writableDestination);

            string dataFromFile = File.ReadAllText(FILEPATH);

            Assert.That(dataFromFile, Is.EqualTo(expectedDataResult));
        }

        [Test]
        public void ExportBookmarkCollectionIntoJsonFormatFile()
        {
            string expectedDataResult = 
                @"[{""Id"":1,""Name"":""My GitHub"",""Url"":""https://github.com/ruben69695""}," +
                @"{""Id"":2,""Name"":""StackOverflow"",""Url"":""https://stackoverflow.com/""}," + 
                @"{""Id"":3,""Name"":""LinkedIn"",""Url"":""https://www.linkedin.com""}]" + Environment.NewLine;

            _dataExporter.Export(TestBookmarks, _writableDestination);

            string dataFromFile = File.ReadAllText(FILEPATH);

            Assert.That(dataFromFile, Is.EqualTo(expectedDataResult));
        }

        private IEnumerable<Bookmark> TestBookmarks 
        {
            get 
            {
                return new List<Bookmark>(new [] {
                    new Bookmark { Id = 1, Name = "My GitHub", Url = "https://github.com/ruben69695" },
                    new Bookmark { Id = 2, Name = "StackOverflow", Url = "https://stackoverflow.com/" },
                    new Bookmark { Id = 3, Name = "LinkedIn", Url = "https://www.linkedin.com" },
                });
            }

        }
    }
}