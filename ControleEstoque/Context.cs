using System.Data.Entity;

namespace ControleEstoque1
{
    public class Context: DbContext
    {
        public Context() : base("DB")
        {
        }
        public DbSet<DtoUsuario> usuario { get; set; }

        public DbSet<dtoProduto> produto { get; set; }
    }
}
