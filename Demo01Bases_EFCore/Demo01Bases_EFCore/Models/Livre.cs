namespace Demo01Bases_EFCore
{
    internal class Livre
    {
        public int Id { get; set; }
        public String? Titre { get; set; }
        public string? Description { get; set; }
        public string? Auteur { get; set; }
        public DateTime DatePublication { get; set; }
    }
}
