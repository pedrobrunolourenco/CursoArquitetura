using System.Collections.Generic;
using NedStore.Core.DomainObjects;

namespace NetStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        protected Categoria()
        {

        }
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo código da categoria não pode estar vazio");
        }

    }

}
