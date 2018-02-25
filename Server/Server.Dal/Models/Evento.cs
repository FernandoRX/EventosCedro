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
		public int HoraInicio { get; set; }
		public int HoraFim { get; set; }
		public bool OpenBar { get; set; }
		public int QuantidadeDeAmbientes { get; set; }
		public string FaixaEtaria { get; set; }
		public int MaximoIngressos { get; set; }
		public int IngressosVendidos { get; set; }

		public IEnumerable<Participante> Participantes { get; set; }

	}
}
