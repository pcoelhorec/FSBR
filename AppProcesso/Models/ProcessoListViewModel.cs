namespace AppProcesso.Models;

public class ProcessoListViewModel
{
    public Int64 Id { get; set; }
    public string? Npu { get; set; }
    public DateTime DataCadastro { get; set; }
    public string? UF { get; set; }
    public DateTime? DataVisualizacao { get; set; }
    public int Municipio { get; set; }
}

