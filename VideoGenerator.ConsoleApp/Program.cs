using VideoGenerator.Services;

var imageDirectoryPath = Directory.GetCurrentDirectory() + @"\images\";
var outputVideoPath = Directory.GetCurrentDirectory() + @"\videos\output.mp4";
if (File.Exists(outputVideoPath))
{
    File.Delete(outputVideoPath);
}
try
{
    ExcelService excelService = new();
    VideoService videoService = new();
    excelService.ReadGraphFromExcel(Directory.GetCurrentDirectory() + @"\Excels\excel.xlsx");
    foreach(var file in Directory.GetFiles(imageDirectoryPath))
    {
        ImageService.ResizeImageIfNotDivisibleBy2(file);
    }
    await videoService.CreateVideoFromImages(imageDirectoryPath, outputVideoPath,".png");
    Console.WriteLine("Video created successfully");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}