using StudentApi.Repositories;

namespace StudentApgi.Repositories
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath=Path.Combine(Directory.GetCurrentDirectory(),@"Resource/Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
            
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resource/Images", fileName);
        }
    }
}
