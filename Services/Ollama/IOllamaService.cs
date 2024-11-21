using AssistenteDeEnsino.Components.Interview.Entities;

namespace AssistenteDeEnsino.Services.Ollama;

public interface IOllamaService
{
    Task<string> ProcessarPergunta(List<Message> Messages);
}