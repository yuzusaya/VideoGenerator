using Xabe.FFmpeg;

namespace VideoGenerator.Services;

public class VideoService
{
    public Task<IConversionResult> CreateVideoFromImages(string imageFolder, string outputVideoPath, string imageExtension = null)
    {
        imageExtension ??= ".jpg";
        var files = Directory.GetFiles(imageFolder, "*" + imageExtension);
#warning "If width or height is not divisible by 2, the conversion will fail"
        var conversion = new Conversion();
        return conversion
        .SetInputFrameRate(0.2)
        .BuildVideoFromImages(files)
        // .SetFrameRate(1)
        .SetPixelFormat(PixelFormat.yuv420p)
        // .SetOutputFormat(Format.mp4)
        .SetOutput(outputVideoPath)
        .Start();
    }
}