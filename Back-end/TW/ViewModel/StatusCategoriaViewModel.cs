using System.ComponentModel.DataAnnotations.Schema;

namespace TW.ViewModel
{
    public class StatusCategoriaViewModel
    {
        [Column("status_categoria")]
        public bool? StatusCategoria { get; set; }
    }
}