using AviModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AviDL
{
    public class AviRepoDB : IAviRepo
    {
        private readonly AviDBContext _context;

        public AviRepoDB(AviDBContext context)
        {
            _context = context;
        }

        public Contributor AddContributor(Contributor newContributor)
        {
            _context.Contributors.Add(newContributor);
            _context.SaveChanges();
            return newContributor;
        }

        public File AddFile(File newFile)
        {
            _context.Files.Add(newFile);
            _context.SaveChanges();
            return newFile;
        }

        public Pilot AddPilot(Pilot newPilot)
        {
            _context.Pilots.Add(newPilot);
            _context.SaveChanges();
            return newPilot;
        }

        public Scene AddScene(Scene newScene)
        {
            _context.Scenes.Add(newScene);
            _context.SaveChanges();
            return newScene;
        }

        public SceneFile AddSceneFile(SceneFile newSF)
        {
            _context.SceneFiles.Add(newSF);
            _context.SaveChanges();
            return newSF;
        }

        public Script AddScript(Script newScript)
        {
            _context.Scripts.Add(newScript);
            _context.SaveChanges();
            return newScript;
        }

        public File DeleteFile(File selectedFile)
        {
            _context.Files.Remove(selectedFile);
            _context.SaveChanges();
            return selectedFile;
        }

        public List<Contributor> GetContributorsByUserID(int userID)
        {
            return _context.Contributors
                .AsNoTracking()
                .Where(c => c.UserID == userID)
                .ToList();
        }

        public List<Contributor> GetContributorsByPilotID(int pilotID)
        {
            return _context.Contributors
                .AsNoTracking()
                .Where(c => c.PilotID == pilotID)
                .ToList();
        }

        public List<File> GetFilesByPilotID(int pilotID)
        {
            return _context.Files
                .AsNoTracking()
                .Where(c => c.PilotID == pilotID)
                .ToList();
        }

        public List<File> GetFilesBySceneId(int sfID)
        {
            return _context.SceneFiles
                .Where(sf => sf.SceneID == sfID)
                .Include(sf => sf.File)
                .AsNoTracking()
                .Select(sf => sf.File)
                .ToList();
        }

        public Pilot GetPilotByID(int id)
        {
            return _context.Pilots
                .Where(p => p.ID == id)
                .Include(p => p.Script)
                .ThenInclude(s => s.ScriptWriter)
                .Include(p => p.Producer)
                .Include(p => p.Files)
                .ThenInclude(f => f.Uploader)
                .Include(p => p.Scenes)
                .ThenInclude(s => s.SceneFiles)
                .ThenInclude(sf => sf.File)
                .ThenInclude(f => f.Uploader)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public List<Scene> GetScenesByPilotID(int pilotID)
        {
            return _context.Scenes
                .AsNoTracking()
                .Where(c => c.PilotID == pilotID)
                .ToList();
        }

        public Script GetScriptByPilotID(int pilotID)
        {
            return _context.Scripts
                .AsNoTracking()
                .FirstOrDefault(sc => sc.PilotID == pilotID);
        }

        public List<Pilot> GetPilots()
        {
            return _context.Pilots
                .AsNoTracking()
                .ToList();
        }
    }
}