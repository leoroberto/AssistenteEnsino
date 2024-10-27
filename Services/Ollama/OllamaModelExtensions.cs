namespace AssistenteDeEnsino.Services.Ollama;

public static class OllamaModelExtensions
{
    public static string ToApiModel(this OllamaModel model)
    {
        return model switch
        {
            OllamaModel.llama3_2 => "llama3.2",
            OllamaModel.llama3_1 => "llama3.1",
            _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
        };
    }
}