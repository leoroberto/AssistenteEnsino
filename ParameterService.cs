using System.Collections;

namespace AssistenteDeEnsino;

public class ParameterService
{
    private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

    public void SetParameter(string key, object value)
    {
        _parameters[key] = value;
    }

    public T GetParameter<T>(string key)
    {
        if (_parameters.TryGetValue(key, out var value) && value is T)
        {
            return (T)value;
        }

        return default;
    }

    public void RemoveParameter(string key)
    {
        _parameters.Remove(key);
    }
}