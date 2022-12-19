namespace ExamenProgramacion.Models
{
    public class DatosUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public Guid idUnique { get; set; }
    }

    public class DatosCompletos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DatosPedidosCompleto pedidos { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public Guid idUnique { get; set; }
    }
}
