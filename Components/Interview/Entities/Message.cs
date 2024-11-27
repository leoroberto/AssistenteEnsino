using Microsoft.Extensions.AI;

namespace AssistenteDeEnsino.Components.Interview.Entities;

public class Message
{
    public string Text { get; set; }
    public MessageType Role { get; set; }
}