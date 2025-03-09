namespace PracticaN2_JosueZamoraConejo.Models
{
    public class ProdCategoria
    {
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
