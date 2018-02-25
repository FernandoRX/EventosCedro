using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Dal.ModelView
{
    public class EventoModelView
    {
		public string Nome { get; set; }
		public DateTime Data { get; set; }
		public string Local { get; set; }
		public int HoraInicio { get; set; }
		public int HoraFim { get; set; }
		public bool OpenBar { get; set; }
		public int QuantidadeDeAmbientes { get; set; }
		public int MaximoIngressos { get; set; }
	}
}
