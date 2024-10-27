namespace AssistenteDeEnsino.Services.Ollama;

using Microsoft.Extensions.AI;

public class OllamaService : IOllamaService
{
    public async Task<string> ProcessarPergunta(string pergunta)
    {
        try
        {
            IChatClient client = new OllamaChatClient(new Uri("http://172.178.79.14:11434/"),
                OllamaModelExtensions.ToApiModel(OllamaModel.llama3_2));

            ChatCompletion completion = await client.CompleteAsync(pergunta);

            return completion.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            return "Desculpe, não foi possível obter uma resposta no momento. Tente novamente mais tarde.";
        }
    }
}