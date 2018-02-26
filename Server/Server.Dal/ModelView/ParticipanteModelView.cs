using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Dal.ModelView
{
    public class ParticipanteModelView
    {
		[Required(ErrorMessage = "O nome é obrigatorio")]
		[StringLength(100)]
		public string Nome { get; set; }
		[Required(ErrorMessage = "O email é obrigatorio")]
		[StringLength(100)]
		[EmailAddress(ErrorMessage="Digite um Email valido")]
		public string Email { get; set; }
		[Required(ErrorMessage = "O evento é obrigatorio para se cadastrar")]
		public int IdEvento { get; set; }
	}
}
