namespace AssistenteDeEnsino.Components.Interview.Entities;

public class Nota
{
    public int Id { get; set; } // Id único para a Nota
    public int Valor { get; set; } // Exemplo de valor da Nota (pode ser de tipo int, decimal, etc.)
    public int UserId { get; set; } // Chave estrangeira para User
    public User User { get; set; } // Navegação para a entidade User
}