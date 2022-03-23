using System.Collections.Generic;

namespace TryCoreTestDeveloper.DataAccess.Entity
{
    public partial class MonMonedaEntity
    {
        public MonMonedaEntity()
        {
            UsrUsuarioEntity = new HashSet<UsrUsuarioEntity>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<UsrUsuarioEntity> UsrUsuarioEntity { get; set; }
    }
}