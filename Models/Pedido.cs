using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneStore.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [StringLength(20)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [StringLength(15)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do pedido")]
        public double PedidoTotal { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Itens no pedido")]
        public int TotalItensPedido { get; set; }

        [Display(Name = "Data do pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEnviado { get; set; }

        [Display(Name = "Data envio pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregueEm { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }
    }
}
