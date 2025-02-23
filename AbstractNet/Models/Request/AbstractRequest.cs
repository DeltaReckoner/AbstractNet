namespace AbstractNet
{
    public class AbstractRequest
    {
        public string Url { get; set; }
        public bool? Lossy { get; set; } = null;
        public uint? Quality { get; set; } = null;
        public ResizeOptions ResizeOptions { get; set; } = null;
    }
}
