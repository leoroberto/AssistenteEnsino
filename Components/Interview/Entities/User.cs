namespace AssistenteDeEnsino.Components.Interview.Entities;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; }
    // Propriedade de navegação para a entidade Nota
    public Nota Nota { get; set; }
}