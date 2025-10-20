using System;
using LojaApi.Entities;
using LojaApi.Infra.Context;
using LojaApi.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Repositories;

public class ProdutoDBRepository : IProdutoRepository
{
    private readonly LojaContext _context;
    public ProdutoDBRepository(LojaContext context) { _context = context; }

    public List<Produto> ObterTodos()
    {
        return _context.Produtos.Include(p => p.Categoria).ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _context.Produtos.Include(p => p.Categoria).FirstOrDefault(p => p.Id == id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        _context.Produtos.Add(novoProduto);
        _context.SaveChanges();
        return novoProduto;
    }
}
