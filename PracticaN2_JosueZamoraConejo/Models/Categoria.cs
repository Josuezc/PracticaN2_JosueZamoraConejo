namespace PracticaN2_JosueZamoraConejo.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<ProdCategoria>? ProdCategorias { get; set; }

    }
}
