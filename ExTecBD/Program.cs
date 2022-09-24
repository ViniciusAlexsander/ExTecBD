using System;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Linq;

namespace ExTecBD
{
    public class Program
    {
        public static readonly string NOME_ARQUIVO = "C:/Temp/ExTecBDFilmes.yap";

        static void Main(string[] args)
        {
            gerarDados();

            Console.WriteLine("Digite 1 ou 2 para escolher o que você quer fazer: ");
            Console.WriteLine("1 - Saber os filmes disponiveis em um streaming ");
            Console.WriteLine("2 - Saber quantos filmes um autor já fez ");
            string streamingFilmesDisponiveis = Console.ReadLine();

            if(streamingFilmesDisponiveis == "1")
                filmesPorStreaming();
            else if(streamingFilmesDisponiveis == "2")
                filmesPorAutor();

            Console.ReadKey();
        }

        static void filmesPorStreaming()
        {
            IObjectContainer db = Db4oFactory.OpenFile(NOME_ARQUIVO);

            try
            {
                Console.Write("Digite um streaming para saber os filmes que estão disponiveis: ");
                string streamingFilmesDisponiveis = Console.ReadLine();

                var queryStreamingFilmesDisponiveis = from Filme f in db
                                                      where f.Streaming.Name == streamingFilmesDisponiveis
                                                      select f;

                foreach (var filmesDisponiveis in queryStreamingFilmesDisponiveis)
                    Console.WriteLine($"Nome do filme: {filmesDisponiveis.Name}, Autor: {filmesDisponiveis.Diretor.Name}, Disponivel em: {filmesDisponiveis.Streaming.Name}");
            }
            catch (Exception)
            {
                Console.Write("Ocorreu um erro :)");
            }
            finally
            {
                db.Close();
            }
        }

        static void filmesPorAutor()
        {
            IObjectContainer db = Db4oFactory.OpenFile(NOME_ARQUIVO);

            try
            {
                Console.Write("Digite um autor para saber quantos filmes ele escreveu: ");
                string autor = Console.ReadLine();
                var queryAutor = from Filme f in db
                                 where f.Diretor.Name == autor
                                 group f by new { f.Diretor.Name } into filmesEncontrados
                                 select new
                                 {
                                     filmesEncontrados.Key.Name,
                                     Qtd = filmesEncontrados.Count()
                                 };

                foreach (var filmesAutor in queryAutor)
                    Console.WriteLine(filmesAutor.Name + " - " + filmesAutor.Qtd);
            }
            catch (Exception)
            {
                Console.Write("Ocorreu um erro :)");
            }
            finally
            {
                db.Close();
            }
        }

        static void gerarDados()
        {
            
            IObjectContainer db = Db4oFactory.OpenFile(NOME_ARQUIVO);

            List<Diretor> autores = new List<Diretor>();
            autores.Add(new Diretor("1", "Diretor 01"));
            autores.Add(new Diretor("2", "Diretor 02"));

            List<Streaming> streamings = new List<Streaming>();
            streamings.Add(new Streaming("1", "Netflix"));
            streamings.Add(new Streaming("2", "Disney Plus"));

            List<Filme> filmes = new List<Filme>();
            filmes.Add(new Filme("1", "Fuga das galinhas", "As galinhas estão fugindo", streamings[0], autores[0]));
            filmes.Add(new Filme("2", "Procurando o nemo 1", "Os peixes estão fugindo", streamings[1], autores[1]));
            filmes.Add(new Filme("3", "Procurando o nemo 2", "Os peixes estão fugindo", streamings[0], autores[1]));
            filmes.Add(new Filme("4", "Procurando o nemo 3", "Os peixes estão fugindo", streamings[1], autores[0]));
            filmes.Add(new Filme("5", "Procurando o nemo 4", "Os peixes estão fugindo", streamings[1], autores[1]));

            db.Store(filmes);
            db.Close();
        }

    }
}