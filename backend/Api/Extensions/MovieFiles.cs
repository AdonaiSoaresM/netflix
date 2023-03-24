namespace API.Extensions
{
    public static class MovieFiles
    {
        public static async Task SaveFiles(Object Data, IFormFileCollection files)
        {
            try
            {
                var id = Data.GetType().GetProperty("Id").GetValue(Data);

                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file.FileName);

                    var fileName = file.Name + "_" + id + Path.GetExtension(file.FileName);

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error in SaveFiles");
            }
        }

        public static async Task DeleteFiles(Guid id)
        {
            try
            {
                string[] files = { $"image-background_{id}.jpg",
            $"image-preview_{id}.jpg",
            $"video_{id}.mp4"};

                foreach (var filename in files)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", filename);

                    File.Delete(filePath);
                }
            }
            catch
            {
                Console.WriteLine("Error in DeleteFiles");
                return;
            }
        }
    }
}