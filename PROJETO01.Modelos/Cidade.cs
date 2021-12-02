using System;
using System.Collections.Generic;
using System.Text;

namespace PROJETO01.Modelos
{
    public class Cidade
    {
        public int CidadeID { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }

        public Estado Estado { get; set; }
    }
}
