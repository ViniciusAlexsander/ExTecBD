using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExTecBD
{
    public class Diretor
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Diretor(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
