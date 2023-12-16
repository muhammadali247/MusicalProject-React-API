using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Abstractions.Services;

public interface IFileService
{
    string ReadFile(string path, string body);
}
