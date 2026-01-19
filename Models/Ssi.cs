using SsiApi.Models;

public class Ssi
{
    public int SsiId { get; set; } // PK

    // FK para Usuario
    public string ChapaSolicitante { get; set; }
    public Usuario Usuario { get; set; }

    public string NomeSolicitante { get; set; }
    public DateTime DataRegistro { get; set; }

    // FK para Servico
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    public int Andamento { get; set; }
    public ICollection<Historico> Historicos { get; set; }
        public ICollection<Peca> Pecas { get; set; }
}
