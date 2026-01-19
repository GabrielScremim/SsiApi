using SsiApi.Models;

public class Historico
{
    public int HistoricoId { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string DescricaoAtualizacao { get; set; }

    // 🔑 FKs
    public int SsiId { get; set; }
    public string UsuarioId { get; set; }

    // 🧭 Navegação
    public Ssi Ssi { get; set; }
    public Usuario Usuario { get; set; }
}
