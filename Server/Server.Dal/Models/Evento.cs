using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Server.Dal.Models
{
    public class Evento
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdEvento { get; set; }
		public string Nome { get; set; }
		public DateTime Data { get; set; }
		public string Local { get; set; }
		public DateTime HoraInicio { get; set; }
		public DateTime HoraFim { get; set; }
		public bool OpenBar { get; set; }
		public int QuantidadeDeAmbientes { get; set; }
		public string FaixaEtária { get; set; }
	}
}
