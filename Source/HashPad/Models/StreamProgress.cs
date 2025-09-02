
namespace HashPad.Models;

/// <summary>
/// Progress data of Stream for IProgress
/// </summary>
internal class StreamProgress(long position, long length)
{
	public long Position { get; } = position;
	public long Length { get; } = length;

	public double Rate => (0L < Length) ? (double)Position / (double)Length : 0D;
}