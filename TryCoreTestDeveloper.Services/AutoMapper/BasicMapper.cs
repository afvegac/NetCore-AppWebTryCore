using TryCoreTestDeveloper.Common.Dto;
using TryCoreTestDeveloper.DataAccess.Entity;

namespace TryCoreTestDeveloper.Services.AutoMapper
{
    public class BasicMapper : global::AutoMapper.Profile
    {
        public BasicMapper()
        {
            CreateMap<UsrUsuarioEntity, UsrUsuarioDto>();
        }
    }
}