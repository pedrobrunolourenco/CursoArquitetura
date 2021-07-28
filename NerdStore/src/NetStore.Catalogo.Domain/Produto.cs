﻿using System;
using NedStore.Core.DomainObjects;

namespace NetStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Produto()
        {

        }
        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime datacadastro, string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = datacadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;
            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategora(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo descrição não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo valor do produto não pode ser menor ou igual a zero");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo categoria do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Imagem, "O campo imagem não pode estar vazio");
        }

    }




}
