using AviBL;
using AviREST.APIModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScriptController : ControllerBase
    {
        private IAviBL _aviBL;
        public ScriptController(IAviBL aviBL)
        {
            _aviBL = aviBL;
        }
        [HttpPost]
        public CreatedID Create(ScriptCreate apiModel)
        {
            foreach (SceneCreate sceneApiModel in apiModel.Scenes)
            {
                sceneApiModel.PilotID = apiModel.PilotID;
                _aviBL.AddScene(sceneApiModel.ToDLModel());
            }
            // TODO: Upload scriptBody to Azure Blob Storage
            apiModel.ScriptURL = "https://www.google.com/";
            return new CreatedID { ID = _aviBL.AddScript(apiModel.ToDLModel()).ID };
        }
    }
}