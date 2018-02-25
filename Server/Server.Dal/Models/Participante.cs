using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Server.Dal.Models
{
    public class Participante
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdParticipante { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
    }
}
