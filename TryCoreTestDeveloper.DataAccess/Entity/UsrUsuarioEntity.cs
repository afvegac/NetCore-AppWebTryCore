namespace TryCoreTestDeveloper.DataAccess.Entity
{
    public partial class UsrUsuarioEntity
    {
        public int Id { get; set; }
        public int? Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int? MonedaId { get; set; }
        public virtual MonMonedaEntity Moneda { get; set; }
    }
}