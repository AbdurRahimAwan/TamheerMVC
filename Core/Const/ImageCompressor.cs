using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;

public class ImageCompressor
{
    public async Task CompressImageAsync(IFormFile file, string destinationPath, int quality)
    {
        await Task.Run(() =>
        {
            using (Image image = Image.Load(file.OpenReadStream()))
            {
                image.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new Size(image.Width, image.Height),
                        Mode = ResizeMode.Max,
                    })
                    .AutoOrient());

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    var encoder = new JpegEncoder
                    {
                        Quality = quality
                    };

                    image.Save(memoryStream, encoder);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                }
            }
        });
    }
}
