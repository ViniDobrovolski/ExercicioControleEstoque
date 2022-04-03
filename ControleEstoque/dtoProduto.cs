using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque1
{
    [Table("produto", Schema = "public")]
    public class dtoProduto
    {
        
            [Key]
            public int id { get; set; }
            public string nome { get; set; }
            public int quantidade { get; set; }
            public string marca { get; set; }
            public decimal preco { get; set; }
            

    }
}
