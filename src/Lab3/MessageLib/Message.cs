namespace Itmo.ObjectOrientedProgramming.Lab3.MessageLib;

public class Message
{
    public string Header { get; }

    public string Body { get; }

    public uint Relevance { get; }

    public Message(string header, string body, uint relevance)
    {
        Header = header;
        Body = body;
        Relevance = relevance;
    }

    public class MessageBuilder : IMessageBuilder
    {
        private string? _header;
        private string? _body;
        private uint _relevance;

        public IMessageBuilder SetHeader(string header)
        {
            _header = header;
            return this;
        }

        public IMessageBuilder SetBody(string body)
        {
            _body = body;
            return this;
        }

        public IMessageBuilder SetRelevance(uint relevance)
        {
            _relevance = relevance;
            return this;
        }

        public Message Build()
        {
            return string.IsNullOrEmpty(_header)
                ? throw new ArgumentException("Header must be set.")
                : string.IsNullOrEmpty(_body) ? throw new ArgumentException("Body must be set.") : new Message(_header, _body, _relevance);
        }

        public override string ToString()
        {
            return $"Message sent with relevance '{_relevance}' with header: '{_header}' and body: '{_body}'";
        }
    }
}