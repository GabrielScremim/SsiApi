namespace SsiApi.Models
{
    public class Usuario
    {
        public string Chapa { get; set; }
        public string Nome { get; set; }
        public string Ramal { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public char Mostrar { get; set; }
        public string AreaTecnico { get; set; }
        public ICollection<Historico> Historicos { get; set; }
        public ICollection<Peca> Pecas { get; set; }
    }
}
