namespace AssistenteDeEnsino.Services.Ollama;

public interface IOllamaService
{
    Task<string> ProcessarPergunta(string pergunta);
}