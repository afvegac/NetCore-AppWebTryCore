using AutoMapper;
using System.Linq;
using TryCoreTestDeveloper.Common.Dto;
using TryCoreTestDeveloper.DataAccess.Entity;
using TryCoreTestDeveloper.DataAccess.Configuration;
using System.Collections.Generic;

namespace TryCoreTestDeveloper.DataAccess.DAO
{
    public interface IUsrUsuarioDAO
    {
        UsrUsuarioEntity Add(UsrUsuarioDto dto);
        void Update(UsrUsuarioDto dto);
        void Delete(int id);
        List<UsrUsuarioDto> GetAll();
    }
    public class UsrUsuarioDAO : IUsrUsuarioDAO
    {
        private readonly TryCoreTestBdContext _contexto;
        private readonly IMapper _mapper;
        public UsrUsuarioDAO(TryCoreTestBdContext contexto,
                           IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }
        public UsrUsuarioEntity Add(UsrUsuarioDto dto)
        {
            var entity = new UsrUsuarioEntity() { };
            entity.Identificacion = dto.Identificacion;
            entity.MonedaId = dto.MonedaId;
            entity.Direccion = dto.Direccion;
            entity.Descripcion = dto.Descripcion;

            _contexto.UsrUsuario.Add(entity);
            _contexto.SaveChanges();
            return entity;
        }
        public void Update(UsrUsuarioDto dto)
        {
            var entity = GetById(dto.Id);
            if (entity != null)
            {
                entity.Identificacion = dto.Identificacion;
                entity.MonedaId = dto.MonedaId;
                entity.Direccion = dto.Direccion;
                entity.Descripcion = dto.Descripcion;

                _contexto.UsrUsuario.Update(entity);
                _contexto.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _contexto.UsrUsuario.Remove(entity);
                _contexto.SaveChanges();
            }
        }
        public UsrUsuarioDto GetByIdentification(string identificacion) => _mapper.Map<UsrUsuarioDto>(_contexto.UsrUsuario.FirstOrDefault(x => x.Identificacion == identificacion));
        public UsrUsuarioDto GetDtoById(int id) => _mapper.Map<UsrUsuarioDto>(_contexto.UsrUsuario.FirstOrDefault(x => x.Id == id));
        private UsrUsuarioEntity GetById(int id) => _contexto.UsrUsuario.FirstOrDefault(x => x.Id == id);
        public List<UsrUsuarioDto> GetAll() => _mapper.Map<IList<UsrUsuarioDto>>(_contexto.UsrUsuario.ToList()).ToList();
    }
}
