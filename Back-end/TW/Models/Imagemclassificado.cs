using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TW.Models
{
    [Table("IMAGEMCLASSIFICADO")]
    public partial class Imagemclassificado
    {
        [Key]
        [Column("id_imagem_classificado")]
        public int IdImagemClassificado { get; set; }
        [Column("imagem")]
        [StringLength(255)]
        public string Imagem { get; set; }
        [Column("id_classificado")]
        public int? IdClassificado { get; set; }

        [ForeignKey(nameof(IdClassificado))]
        [InverseProperty(nameof(Classificado.Imagemclassificado))]
        public virtual Classificado IdClassificadoNavigation { get; set; }
    }
}
