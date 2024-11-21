using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneStore.Models
{
    [Table("T_ROUPA")]
    public class Roupa
    {
        [Key]
        public int RoupaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da roupa.")]
        [Display(Name = "Nome da roupa")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O tamanho mínimo é 5 caracteres e o máximo é 100 caracteres.")]
        public string RoupaNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição da roupa.")]
        [Display(Name = "Descrição da roupa")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "O tamanho mínimo é 5 caracteres e o máximo é 100 caracteres.")]
        public string RoupaDescricao { get; set; }

        [Required(ErrorMessage = "Informe o preço da roupa.")]
        [Display(Name = "Preço da roupa")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1 ,999.99 ,ErrorMessage ="O preço deve estar entre 1 e 999.99 reais.")]
        public double RoupaPreco { get; set; }

        [Display(Name = "Caminho da imagem")]
        [MaxLength(200 ,ErrorMessage = "O caminho pode ter no máximo 200 caracteres.")]
        public string RoupaUrlImagem { get; set; }

        [Display(Name = "Em destaque?")]
        public bool RoupaDestaque { get; set; }

        [Display(Name = "Em estoque?")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
