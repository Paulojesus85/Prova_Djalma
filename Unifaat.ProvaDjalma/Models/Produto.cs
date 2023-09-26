using System.ComponentModel.DataAnnotations;
using Unifaat.ProvaDjalma.Models.Interfaces;

namespace Unifaat.ProvaDjalma.Models
{
    public class Produto : IStatusModificacao
    {
        public int ProdutoId { get; set; }

        [MaxLength(128)]
        public string ProdutoDescricao { get; set; }

        [MaxLength(128)]
        public string ProdutoNome { get; set; }

        public double ProdutoPreco { get; set; }

        public int QtdeEmEstoque { get; set; }

        #region Interface
        [ScaffoldColumn(false)]
        [Display(Name = "Excluído")]
        public bool Excluido { get; set; }
        #endregion

        public int MarcaId { get; set; }
        public Marca? Marca { get; set; }
    }
}