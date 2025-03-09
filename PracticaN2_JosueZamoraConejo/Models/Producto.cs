namespace PracticaN2_JosueZamoraConejo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public ICollection<ProdCategoria>? ProdCategorias { get; set; }

    }
}
