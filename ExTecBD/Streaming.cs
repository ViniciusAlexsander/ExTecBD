using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExTecBD
{
    public class Streaming
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Streaming(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
