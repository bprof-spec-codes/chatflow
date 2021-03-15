using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class AdministratorLogic : IAdministratorLogic
    {
        ICommonRepository<Administrator> administratorRepository;

        public AdministratorLogic(ICommonRepository<Administrator> administratorRepository)
        {
            this.administratorRepository = administratorRepository;
        }

        public void AddAdministrator(Administrator administrator)
        {
            administratorRepository.Add(administrator);
        }

        public void DeleteAdministrator(Administrator administrator)
        {
            administratorRepository.Delete(administrator);
        }

        public IQueryable<Administrator> GetAllAdministrator()
        {
            return administratorRepository.GetAll();
        }

        public Administrator GetOneAdministrator(string idAdministrator)
        {
            return administratorRepository.GetOne(idAdministrator);
        }

        public void UpdateAdministrator(Administrator updatedAdministrator)
        {
            administratorRepository.Update(updatedAdministrator);
        }
    }
}
