using System;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ProdutoService(
        IProdutoRepository produtoRepository,
        ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public List<Produto> ObterTodos()
    {
        return _produtoRepository.ObterTodos().Where(p => p.Estoque > 0).ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _produtoRepository.ObterPorId(id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        var categoria = _categoriaRepository.ObterPorId(novoProduto.CategoriaId);
        if (categoria == null)
        { 
            throw new Exception("A categoria informada não existe.");
        }

        if (categoria.Nome.Equals("Eletrônicos", StringComparison.OrdinalIgnoreCase) && novoProduto.Preco < 60.00m)
        {
            throw new Exception("Produtos da categoria 'Eletrônicos' devem custar no mínimo R$ 60,00.");
        }

        return _produtoRepository.Adicionar(novoProduto);
    }
}
