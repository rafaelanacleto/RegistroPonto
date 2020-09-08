using System;
using System.Collections.Generic;

namespace PontoEletronico.Domain
{
    public class PontoRegistro
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public char EntradaSaida { get; set; }
        public DateTime? Registro { get; set; }
    }
}