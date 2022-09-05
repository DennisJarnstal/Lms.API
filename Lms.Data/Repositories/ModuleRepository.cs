using Lms.Core.Entities;
using Lms.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    internal class ModuleRepository : IModuleRepository
    {
        private readonly IModuleRepository _moduleRepository;

        public void Add(Module module)
        {
            _moduleRepository.Add(module);
        }

        public Task<bool> AnyAsync(int? id)
        {
            return _moduleRepository.AnyAsync(id);
        }

        public Task<Module> FindAsync(int? id)
        {
            return _moduleRepository.FindAsync(id);
        }

        public Task<IEnumerable<Module>> GetAllModules()
        {
            return _moduleRepository.GetAllModules();
        }

        public Task<Module> GetModule(int? id)
        {
            return _moduleRepository.GetModule(id);
        }

        public void Remove(Module module)
        {
            _moduleRepository.Remove(module);
        }

        public void Update(Module module)
        {
            _moduleRepository.Update(module);
        }
    }
}
