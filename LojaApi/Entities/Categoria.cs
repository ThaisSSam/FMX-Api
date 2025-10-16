using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

[Table("TB_CATEGORIAS")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }

    [Column("nome_categoria")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter mais que 3 e menos que 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
