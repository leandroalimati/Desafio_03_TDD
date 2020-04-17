
namespace LojaFilmes
{
    public class Filmes
    {
        public int IdFilme { get; set; }
        public string NomeFilme { get; set; }
        public string Genero { get; set; }
        public double Preco { get; set; }

        public Filmes(int idFilme, string nomeFilme, string genero, double preco)
        {
            this.IdFilme = idFilme;
            this.NomeFilme = nomeFilme;
            this.Genero = genero;
            this.Preco = preco;
        }
    }
}
