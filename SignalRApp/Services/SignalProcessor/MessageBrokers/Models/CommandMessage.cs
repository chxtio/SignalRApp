using System;

namespace SignalRApp
{
    public sealed class CommandMessage
    {
        public string Id { get; }
        public string Command { get; }
        public DateTime CreatedDateTime { get; }

        public CommandMessage(string id, string command, DateTime createdDateTime)
        {
            Id = id;
            Command = command;
            CreatedDateTime = createdDateTime;
        }
    }
}
