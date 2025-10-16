using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaApi.Entities;

[Table("TB_PRODUTOS")]
public class Produto
{
    [Key]
    [Column("id_produto")]
    public int Id { get; set; }

    [Column("nome_produto")]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome deve ter mais que 3 e menos que 150 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Column("preco_produto", TypeName = "decimal(10, 2)")]
    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, 100000.00, ErrorMessage = "O preço deve ser entre 0,01 e 100.000,00.")]
    public decimal Preco { get; set; }

    [Column("estoque_produto")]
    [Range(0, 9999, ErrorMessage = "O estoque deve ser entre 0 e 9999.")]
    public int Estoque { get; set; }

    [Column("id_categoria")]
    [Required(ErrorMessage = "O ID é obrigatório.")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}
