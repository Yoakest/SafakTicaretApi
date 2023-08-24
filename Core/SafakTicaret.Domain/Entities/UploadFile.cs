using SafakTicaret.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafakTicaret.Domain.Entities
{
	public class UploadFile : BaseEntity
	{
		[NotMapped]
		public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
		public string FileName { get; set; }
		public string Path { get; set; }


	}
}
