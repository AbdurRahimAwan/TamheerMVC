using Microsoft.AspNetCore.Http;


namespace Core.IRepository
{
    public interface IpdfService
    {
        Task<(bool isUploaded, string? errorMessage)> UploadAsync(IFormFile pdffile, string pdfFileName, string folderPath);
        void Delete(string pdfFilePath);
    }
}
