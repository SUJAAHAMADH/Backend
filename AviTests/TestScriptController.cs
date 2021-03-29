using AviBL;
using AviModels;
using AviREST.APIModels;
using AviREST.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Xunit;

namespace AviTests
{
    public class TestScriptController
    {
        private Mock<IAviBL> _aviMock;
        private Mock<BlobServiceClient> _bscMock;
        public TestScriptController()
        {
            _aviMock = new Mock<IAviBL>();
            _bscMock = new Mock<BlobServiceClient>();
        }

        [Fact]
        public async Task CreateShouldReturnCreatedID()
        {
            var newScene = new Scene() { ID = 1};
            var newScript = new Script() { ID = 1};
            var ccMock = new Mock<BlobContainerClient>();
            var bcMock = new Mock<BlobClient>();
            var newScriptCreate = new ScriptCreate { PilotID = 1,
                Scenes = new List<SceneCreate> { new SceneCreate()}
            };
            _aviMock.Setup(x => x.AddScene(It.IsAny<Scene>())).Returns(newScene);
            _aviMock.Setup(x => x.AddScript(It.IsAny<Script>())).Returns(newScript);
           // _bscMock.Setup(x => x.CreateBlobContainer(It.IsAny<string>())).Returns(ccMock);

            var newAviqtorBL = new ScriptController(_aviMock.Object, _bscMock.Object);
            var result = newAviqtorBL.Create(newScriptCreate);

            Assert.IsAssignableFrom<CreatedID>(result);
            Assert.Equal(result.ID, newScriptCreate.PilotID);
            _aviMock.Verify(x => x.AddScene(It.IsAny<Scene>()));
        }
    }
}
