namespace _01.Stream_Progress
{
    public interface IStreamable
    {
        int BytesSent { get; }
        int Length { get; }
    }
}