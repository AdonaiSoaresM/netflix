using FFMpegCore.Pipes;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Arguments;

namespace API.Extensions
{
    public static class MovieFiles
    {
        public static async Task SaveFiles(Object Data, IFormFileCollection files)
        {
            //try
            //{
            Console.WriteLine("________________________________________________________________");
            var id = Data.GetType().GetProperty("Id").GetValue(Data);

            var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\" + id);

            Directory.CreateDirectory(pathFolder);

            foreach (var file in files)
            {
                if (file.ContentType.Contains("video"))
                {
                    var fileName = "video.m3u8";

                    string outputPath = Path.Combine(pathFolder, fileName);

                    string pathMp4 = Path.Combine(pathFolder, "video.mp4");

                    using (var stream = new FileStream(pathMp4, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    await FFMpegArguments.FromFileInput(pathMp4).OutputToFile(outputPath, true, options =>
                    {
                        options.WithCustomArgument("-profile:v baseline -level 3.0 -s 640x360 -start_number 0 -hls_time 10 -hls_list_size 0 -f hls");
                    }).ProcessAsynchronously();

                    File.Delete(pathMp4);
                }
                else
                {
                    var extension = Path.GetExtension(file.FileName);

                    var fileName = file.Name + Path.GetExtension(file.FileName);

                    var filePath = Path.Combine(pathFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        public static async Task DeleteFiles(Guid id)
        {
            try
            {
                var pathFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/" + id);
                Directory.Delete(pathFolder, true);
            }
            catch
            {
                Console.WriteLine("Error in DeleteFiles");
                return;
            }
        }
    }
}