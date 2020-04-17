using NUnit.Framework;
using System.Collections;

namespace LojaFilmes
{
    [TestFixture]
    public class LojaFilmesDescontoTest
    {
        /// <summary>
        // Critérios
            // • Acima de R$ 100 e abaixo de R$ 200 => 10%
            // • Acima de R$ 200 e abaixo de R$ 300 => 20%
            // • Acima de R$ 300 e abaixo de R$ 400 => 25%
            // • Acima de R$ 400 => 30%
            // • Se existir no carrinho um filme com gênero ação somar + 5% de desconto
        /// </summary>

        ArrayList carrinho;
        readonly Filmes SenhorDosAneis = new Filmes(1, "Senhor dos Anéis", "Fantasia", 45.00);
        readonly Filmes AsBranquelas = new Filmes(2, "As Branquelas", "Comédia", 55.00);
        readonly Filmes VelozesEFuriosos7 = new Filmes(3, "Velozes e Furiosos 7", "Ação", 100.00);
        readonly Filmes VelozesEFuriosos6 = new Filmes(4, "Velozes e Furiosos 6", "Ação", 55.00);
        readonly Filmes TheScapeGoat = new Filmes(5, "The Scape Goat", "Drama", 100.00);
        readonly Filmes MeuMalvadoFavorito = new Filmes(6, "Meu Malvado Favorito", "Animação", 200.00);
        public double CalcularDesconto(ArrayList carrinho)
        {
            int desconto = 0;
            double valorTotal = 0;
            bool acao = false;

            for (int i = 0; i < carrinho.Count; i++)
            {
                Filmes filmes = (Filmes)carrinho[i];
                valorTotal += filmes.Preco;
                if (filmes.Genero == "Ação")
                    acao = true;
            }

            if (valorTotal > 100.00 && valorTotal <= 200.00)
            {
                desconto = 10;
            }
            if (valorTotal > 200.00 && valorTotal <= 300.00)
            {
                desconto = 20;
            }
            if (valorTotal > 300.00 && valorTotal <= 400.00)
            {
                desconto = 25;
            }
            else if (valorTotal > 400.00)
            {
                desconto = 30;
            }

            if (acao)
                desconto += 5;

            return desconto;
        }

        [TestCase(TestName = "0% de desconto")]
        public void SemDesconto()
        {
            carrinho = new ArrayList
            {
                AsBranquelas
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(0, desconto);
        }

        [TestCase(TestName = "10% de desconto acima de R$100 e abaixo de R$200")]
        public void DescontoEntre100e200()
        {
            carrinho = new ArrayList
            {
                SenhorDosAneis,
                TheScapeGoat
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(10, desconto);
        }

        [TestCase(TestName = "20% de desconto acima de R$200 e abaixo de R$300")]
        public void DescontoEntre200e300()
        {
            carrinho = new ArrayList
            {
                SenhorDosAneis,
                AsBranquelas,
                MeuMalvadoFavorito
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(20, desconto);
        }

        [TestCase(TestName = "25% de desconto acima de R$300 e abaixo de R$400")]
        public void DescontoEntre300e400()
        {
            carrinho = new ArrayList
            {
                TheScapeGoat,
                MeuMalvadoFavorito,
                AsBranquelas
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(25, desconto);
        }

        [TestCase(TestName = "30% de desconto acima de R$400")]
        public void DescontoTrintaPorCento()
        {
            carrinho = new ArrayList
            {
                MeuMalvadoFavorito,
                AsBranquelas,
                SenhorDosAneis,
                TheScapeGoat,
                TheScapeGoat
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(30, desconto);
        }

        [TestCase(TestName = "35% de desconto acima de R$400 + gênero de ação")]
        public void DescontoMaximo()
        {
            carrinho = new ArrayList
            {
                AsBranquelas,
                VelozesEFuriosos6,
                MeuMalvadoFavorito,
                TheScapeGoat
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(35, desconto);
        }
        [TestCase(TestName = "5% de desconto gênero de ação")]
        public void DescontoGeneroAcao()
        {
            carrinho = new ArrayList
            {
                VelozesEFuriosos7
            };
            double desconto = CalcularDesconto(carrinho);
            Assert.AreEqual(5, desconto);
        }
    }
}
