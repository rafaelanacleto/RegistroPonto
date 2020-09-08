using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.API.Dtos
{
    public class PontoRegistroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public char EntradaSaida { get; set; }
        public DateTime? Registro { get; set; }
    }
}