
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace VideoGenerator.Services;

public class ImageService
{
    //resize image
    public static void ResizeImageIfNotDivisibleBy2(string imagePath)
    {
        using var image = Image.Load<Rgba32>(imagePath);
        var width = image.Width;
        var height = image.Height;
        var resize = false;
        if (width%2!=0)
        {
            width -= 1;
            resize = true;
        }
        if (height % 2 != 0)
        {
            height -= 1;
            resize = true;
        }
        if (!resize)
        {
            return;
        }
        image.Mutate(x => x.Resize(width, height));
        image.Save(imagePath);
    }
}
