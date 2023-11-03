using System.ComponentModel.DataAnnotations;

namespace ApiTarefa.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
