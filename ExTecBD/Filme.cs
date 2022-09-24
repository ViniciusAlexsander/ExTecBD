using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExTecBD
{
    public class Filme
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Streaming Streaming { get; set; }
        public Autor Autor { get; set; }

        public Filme(string id, string name, string description, Streaming streaming, Autor autor)
        {
            Id = id;
            Name = name;
            Description = description;
            Streaming = streaming;
            Autor = autor;
        }
    }
}
