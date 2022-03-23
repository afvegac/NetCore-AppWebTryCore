using System.Collections.Generic;
using TryCoreTestDeveloper.Common.Dto;
using TryCoreTestDeveloper.DataAccess.DAO;

namespace TryCoreTestDeveloper.Services.Service
{
    public interface IUsrUsuarioService
    {
        UsrUsuarioDto Add(UsrUsuarioDto dto);
        void Delete(int id);
        void Update(UsrUsuarioDto dto);
        List<UsrUsuarioDto> GetAll();
    }
    public class UsrUsuarioService : IUsrUsuarioService
    {
        private readonly IUsrUsuarioDAO _usrUsuarioDAO;
        public UsrUsuarioService(IUsrUsuarioDAO usrUsuarioDAO)
        {
            _usrUsuarioDAO = usrUsuarioDAO;
        }
        public UsrUsuarioDto Add(UsrUsuarioDto dto)
        {
            _usrUsuarioDAO.Add(dto);
            return dto;
        }
        public List<UsrUsuarioDto> GetAll()
        {
            return _usrUsuarioDAO.GetAll();
        }
        public void Delete(int id) => _usrUsuarioDAO.Delete(id);
        public void Update(UsrUsuarioDto dto) => _usrUsuarioDAO.Update(dto);
    }
}