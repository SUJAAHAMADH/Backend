using AviModels;
using System;
using System.Collections.Generic;
using System.Text;
using AviDL;

namespace AviBL
{
    public class AviatorBL : IAviBL
    {
        private IAviRepo _repo;

        public AviatorBL(IAviRepo repo)
        {
            _repo = repo;
        }

        public Contributor AddContributor(Contributor newContributor)
        {
            return _repo.AddContributor(newContributor);
        }

        public File AddFile(File newFile)
        {
            return _repo.AddFile(newFile);
        }

        public Pilot AddPilot(Pilot newPilot)
        {
            return _repo.AddPilot(newPilot);
        }

        public Scene AddScene(Scene newScene)
        {
            return _repo.AddScene(newScene);
        }

        public SceneFile AddSceneFile(SceneFile newSF)
        {
            return _repo.AddSceneFile(newSF);
        }

        public Script AddScript(Script newScript)
        {
            return _repo.AddScript(newScript);
        }

        public File DeleteFile(File selectedFile)
        {
            return _repo.DeleteFile(selectedFile);
        }

        public List<Contributor> GetContributorsByUserID(int userID)
        {
            return _repo.GetContributorsByUserID(userID);
        }

        public List<Contributor> GetContributorsByPilotID(int pilotID)
        {
            return _repo.GetContributorsByPilotID(pilotID);
        }

        public List<File> GetFilesByPilotID(int pilotID)
        {
            return _repo.GetFilesByPilotID(pilotID);
        }

        public List<File> GetFilesBySceneId(int sfID)
        {
            return _repo.GetFilesBySceneId(sfID);
        }

        public Pilot GetPilotByID(int id)
        {
            return _repo.GetPilotByID(id);
        }

        public List<Scene> GetScenesByPilotID(int pilotID)
        {
            return _repo.GetScenesByPilotID(pilotID);
        }

        public Script GetScriptByPilotID(int pilotID)
        {
            return _repo.GetScriptByPilotID(pilotID);
        }

        public List<Pilot> GetPilots()
        {
            return _repo.GetPilots();
        }
    }
}
