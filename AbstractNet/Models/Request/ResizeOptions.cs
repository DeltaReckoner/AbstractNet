namespace AbstractNet
{
    public class ResizeOptions
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public ResizeMode Strategy { get; set; }
        public uint Scale { get; set; }
        public CropMode Crop { get; set; }
    }
}
