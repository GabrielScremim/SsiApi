namespace SsiApi.Models
{
    public class Peca
    {
        public int PecaId { set; get; }
        public DateTime DataPeca { set; get; }
        public string Descricao { set; get; }
        public decimal Valor { set; get; }
        public int SsiId { get; set; }
        public Ssi Ssi { set; get; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { set; get; }
    }
}