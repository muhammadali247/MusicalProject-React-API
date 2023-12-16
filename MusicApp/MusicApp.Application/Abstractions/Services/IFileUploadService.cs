using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Services;

public interface IFileUploadService
{
    Task<string> UploadFileAsync(byte[] fileData, string fileName, string targetDirectory);
    Task<byte[]> ReadFileDataAsync(Stream stream);
}
