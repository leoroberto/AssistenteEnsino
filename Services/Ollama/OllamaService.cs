using AssistenteDeEnsino.Components.Interview.Entities;

namespace AssistenteDeEnsino.Services.Ollama;

using Microsoft.Extensions.AI;

public class OllamaService : IOllamaService
{
    public async Task<string> ProcessarPergunta(List<Message> messages)
    {
        List<ChatMessage>? chatMessages = new List<ChatMessage>();
        
        try
        {
            IChatClient client = new OllamaChatClient(new Uri("http://172.178.79.14:11434/"),
                OllamaModelExtensions.ToApiModel(OllamaModel.llama3_2));

            foreach (var message in messages)
            {
                chatMessages.Add(new ChatMessage(message.IsUser ? ChatRole.User : ChatRole.Assistant, message.Text));
            }

            ChatCompletion completion = await client.CompleteAsync(chatMessages);

            return completion.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");

            return "Desculpe, não foi possível obter uma resposta no momento. Tente novamente mais tarde.";
        }
    }
}