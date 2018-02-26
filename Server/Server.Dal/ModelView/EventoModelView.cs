using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Dal.ModelView
{
    public class EventoModelView
    {
		[Required(ErrorMessage="o campo Nome é obrigatorio")]
		[StringLength(100)]
		public string Nome { get; set; }
		public DateTime Data { get; set; }
		[Required(ErrorMessage = "Local do evento é obrigatorio")]
		[StringLength(100)]
		public string Local { get; set; }
		[Required(ErrorMessage = "Hora do inicio deve ser definida")]
		public int HoraInicio { get; set; }
		[Required(ErrorMessage = "Hora do fim deve ser definida")]
		public int HoraFim { get; set; }
		[Required(ErrorMessage = "Defina se o evento sera openBar")]
		public bool OpenBar { get; set; }
		public int QuantidadeDeAmbientes { get; set; }
		[Required(ErrorMessage = "Defina a quantidade de ingressos")]
		public int MaximoIngressos { get; set; }
	}
}
