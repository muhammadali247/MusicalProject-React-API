using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.Exceptions;

namespace MusicApp.WebApi.Implementations.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public FileUploadService(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<string> UploadFileAsync(byte[] fileData, string fileName, string targetDirectory)
    {
        if (fileData == null || fileData.Length == 0) throw new Application.Exceptions.BadRequestException("File data is empty or null.");
        if (string.IsNullOrEmpty(fileName)) throw new Application.Exceptions.BadRequestException("File name is empty or null.");
        if (string.IsNullOrEmpty(targetDirectory)) throw new Application.Exceptions.BadRequestException("Target directory is empty or null.");

        // Generate a unique file name to avoid conflicts
        string uniqueFileName = $"{Guid.NewGuid().ToString()}_{fileName}";

        // Combine the file path with the target directory and unique filename
        string relativeFilePath = Path.Combine(targetDirectory, uniqueFileName);

        // Get the path to the uploads directory in the web root path
        string uploadsDirectory = Path.Combine(_hostingEnvironment.WebRootPath, targetDirectory);

        // Create the target directory if it doesn't exist
        Directory.CreateDirectory(uploadsDirectory);

        // Combine the file path with the target directory
        string absoluteFilePath = Path.Combine(uploadsDirectory, uniqueFileName);

        // Write the file data to the file path
        await File.WriteAllBytesAsync(absoluteFilePath, fileData);

        // Return the relative file path
        return uniqueFileName;
    }

    public async Task<byte[]> ReadFileDataAsync(Stream stream)
    {
        using (var memoryStream = new MemoryStream())
        {
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
   
}
