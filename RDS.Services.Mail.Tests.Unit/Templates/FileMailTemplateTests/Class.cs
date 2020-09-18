using Moq;
using RDS.Services.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace MailServiceTest.FileMailTemplateTests
{
    [Trait("Category", "FileMailTemplate")]
    public class Class
    {
        FileMailTemplate _template;
        IFileSystem _fileSystem = Mock.Of<IFileSystem>();
        string _fileContent = "File content";
        string _templateName = "Template name";
        string _correctPath = "path";

        public Class()
        {
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(_correctPath)).Returns(true);
            Mock.Get(_fileSystem).Setup(f => f.File.ReadAllText(_correctPath)).Returns(_fileContent);
            Mock.Get(_fileSystem)
                .Setup(f => f.Path.Combine(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string a, string b) => { return Path.Combine(a, b); });
            Mock.Get(_fileSystem)
                .Setup(f => f.Path.Combine(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string a, string b, string c) => { return Path.Combine(a, b, c); });
            Mock.Get(_fileSystem)
               .Setup(f => f.Path.Combine(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .Returns((string a, string b, string c) => { return Path.Combine(a, b, c); });

            _template = new FileMailTemplate(_fileSystem);
        }

        [Fact]
        public void ItExists()
        {
            FileMailTemplate reader = new FileMailTemplate();
        }

        [Fact]
        public void ItImplementIMailTemplate()
        {
            Assert.IsAssignableFrom<IMailTemplate>(_template);
        }

        [Fact]
        public void ItHasPathWritableProperty()
        {
            _template.Path = _correctPath;

            Assert.Equal(_correctPath, _template.Path);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ItHasStoreInMemoryWritableProperty(bool storeInMemory)
        {
            _template.StoreInMemory = storeInMemory;

            Assert.Equal(storeInMemory, _template.StoreInMemory);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ItHasIsBodyHtmlWritableProperty(bool value)
        {
            _template.IsBodyHtml = value;

            Assert.Equal(value, _template.IsBodyHtml);
        }

        [Fact]
        public void GivenNotExistingFilePathThenThrowArgumentExeption()
        {
            var result = Record.Exception(() => _template.Path = "badPath");

            Assert.IsAssignableFrom<ArgumentException>(result.GetBaseException());
            Assert.StartsWith("File not found", result.Message);
            Assert.Contains("path", ((ArgumentException)result).ParamName);
        }

        [Fact]
        public void GivenExistingFileNameInCurrentDirectoryThenCorrectPath()
        {
            string fileName = "file.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(true);

            _template.Path = fileName;

            Assert.Equal(path, _template.Path);
        }

        [Fact]
        public void GivenExistingFileNameInDefaultTemplatePathThenCorrectPath()
        {
            string fileName = "file.txt";
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot\\templates\\mail\\", fileName);
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(true);

            _template.Path = fileName;

            Assert.Equal(path, _template.Path);
        }

        [Fact]
        public void BodyParameterReqestedThenReadFile()
        {
            FileMailTemplate reader = new FileMailTemplate(_fileSystem)
            {
                Name = _templateName,
                Path = _correctPath
            };

            string result = reader.Body;

            Assert.Equal(_fileContent, result);
            Mock.Get(_fileSystem).Verify(f => f.File.ReadAllText(_correctPath), Times.Once);
        }

        [Fact]
        public void StoreInMemoryEnabledThenReadFileOnce()
        {
            FileMailTemplate reader = new FileMailTemplate(_fileSystem)
            {
                Name = _templateName,
                Path = _correctPath,
                StoreInMemory = true
            };

            for (int i = 0; i < 10; i++)
            {
                string result = reader.Body;
                Assert.Equal(_fileContent, result);
            }

            Mock.Get(_fileSystem).Verify(f => f.File.ReadAllText(_correctPath), Times.Once);
        }

        [Fact]
        public void StoreInMemoryDisabledThenReadFileAtRead()
        {
            FileMailTemplate reader = new FileMailTemplate(_fileSystem)
            {
                Name = _templateName,
                Path = _correctPath,
                StoreInMemory = false
            };
            int readCount = 10;

            for (int i = 0; i < readCount; i++)
            {
                string result = reader.Body;
                Assert.Equal(_fileContent, result);
            }

            Mock.Get(_fileSystem).Verify(f => f.File.ReadAllText(_correctPath), Times.Exactly(readCount));
        }

        [Fact]
        public void AfterCreationFileDeleteThenNullBodyReturned()
        {
            string path = "new path";
            string content = "new content";
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(true);
            Mock.Get(_fileSystem).Setup(f => f.File.ReadAllText(_correctPath)).Returns(content);
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(false);
            Mock.Get(_fileSystem).Setup(f => f.File.ReadAllText(_correctPath)).Throws(new Exception());
            FileMailTemplate reader = new FileMailTemplate(_fileSystem)
            {
                Name = _templateName,
                Path = _correctPath
            };

            string result = reader.Body;

            Assert.Null(result);
        }

        [Fact]
        public void AfterCreationFileUnableReadThenNullBodyReturned()
        {
            string path = "new path";
            string content = "new content";
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(true);
            Mock.Get(_fileSystem).Setup(f => f.File.ReadAllText(_correctPath)).Returns(content);
            Mock.Get(_fileSystem).Setup(f => f.File.Exists(path)).Returns(true);
            Mock.Get(_fileSystem).Setup(f => f.File.ReadAllText(_correctPath)).Throws(new Exception());
            FileMailTemplate reader = new FileMailTemplate(_fileSystem)
            {
                Name = _templateName,
                Path = _correctPath
            };

            string result = reader.Body;

            Assert.Null(result);
        }
    }
}
