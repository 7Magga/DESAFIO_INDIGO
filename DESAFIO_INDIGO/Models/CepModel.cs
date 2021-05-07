using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DESAFIO_INDIGO.Models
{
    public class CepModel
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string estado { get; set; }
        public string bairro { get; set; }
    }
}