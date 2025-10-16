using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Entities
{
    [Table("TB_CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int Id { get; set; }

        [Column("nome_cliente")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome não pode ter menos que 3 caracteres.")]
        public string Nome { get; set; } = string.Empty;
        
        [Column("email_cliente")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        public string Email { get; set; } = string.Empty;

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}
