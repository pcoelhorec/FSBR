using System.ComponentModel.DataAnnotations;

namespace AppProcesso.Models
{
    public class Processo
    {
        public Int64 Id { get; set; }
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$")]
        public string? Npu { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataVisualizacao { get; set; }
        public string? UF { get; set; }
        public int Municipio { get; set; }
        
    }

}
