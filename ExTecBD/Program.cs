using System;

namespace ExTecBD // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Autor> autores = new List<Autor>();
            autores.Add(new Autor("1", "Autor 01"));
            autores.Add(new Autor("2", "Autor 02"));

            List<Streaming> streamings = new List<Streaming>();
            streamings.Add(new Streaming("1", "Netflix"));
            streamings.Add(new Streaming("2", "Disney Plus"));

            List<Filme> filmes = new List<Filme>();
            filmes.Add(new Filme("1", "Fuga das galinhas", "As galinhas estão fugindo", streamings[0], autores[0]));
            filmes.Add(new Filme("2", "Procurando o nemo 1", "Os peixes estão fugindo", streamings[1], autores[1]));
            filmes.Add(new Filme("3", "Procurando o nemo 2", "Os peixes estão fugindo", streamings[0], autores[1]));
            filmes.Add(new Filme("4", "Procurando o nemo 3", "Os peixes estão fugindo", streamings[1], autores[0]));
            filmes.Add(new Filme("5", "Procurando o nemo 4", "Os peixes estão fugindo", streamings[1], autores[1]));

            Console.Write("Digite um streaming para saber quantos filmes estão disponiveis: ");
            string streaming = Console.ReadLine();
            var queryStreaming = from f in filmes
                         where f.Streaming.Name == streaming
                         group f by new { f.Streaming.Name } into streamingsFind
                         select new
                         {
                             streamingsFind.Key.Name,
                             Qtd = streamingsFind.Count()
                         };

            foreach (var stream in queryStreaming)
                Console.WriteLine(stream.Name + " - " + stream.Qtd);


            Console.Write("Digite um streaming para saber os filmes filmes disponiveis: ");
            string streamingFilmesDisponiveis = Console.ReadLine();
            var queryStreamingFilmesDisponiveis = from f in filmes
                                                  where f.Streaming.Name == streamingFilmesDisponiveis
                                                  select f;

            foreach (var filmesDisponiveis in queryStreamingFilmesDisponiveis)
                Console.WriteLine($"Nome do filme: {filmesDisponiveis.Name}, Autor: {filmesDisponiveis.Autor.Name}, Disponivel em: {filmesDisponiveis.Streaming.Name}");


            Console.Write("Digite um autor para saber quantos filmes ele escreveu: ");
            string autor = Console.ReadLine();
            var queryAutor = from f in filmes
                         where f.Autor.Name == autor
                         group f by new { f.Autor.Name } into filmesEncontrados
                         select new
                         {
                             filmesEncontrados.Key.Name,
                             Qtd = filmesEncontrados.Count()
                         };

            foreach (var filmesAutor in queryAutor)
                Console.WriteLine(filmesAutor.Name + " - " + filmesAutor.Qtd);

            Console.ReadKey();
        }
    }
}