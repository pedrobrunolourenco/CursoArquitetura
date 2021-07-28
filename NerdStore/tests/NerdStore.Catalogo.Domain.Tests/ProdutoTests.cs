using System;
using NedStore.Core.DomainObjects;
using NetStore.Catalogo.Domain;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() =>
           {
               new Produto(string.Empty, "descri��o", false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(2,2,2));
           });
           Assert.Equal("O campo nome do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("Nome", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(2, 2, 2));
            });
            Assert.Equal("O campo descri��o n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("Nome", "Descri��o", false, 0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(2, 2, 2));
            });
            Assert.Equal("O campo valor do produto n�o pode ser menor ou igual a zero", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("Nome", "Descri��o", false, 10, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(2, 2, 2));
            });
            Assert.Equal("O campo categoria do produto n�o pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
            {
                new Produto("Nome", "Descri��o", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(2, 2, 2));
            });
            Assert.Equal("O campo imagem n�o pode estar vazio", ex.Message);



        }
    }
}
