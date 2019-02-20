using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeAPI.Services.Interfaces
{
    public interface IFileService
    {
        void SaveImage(string base64ImageString, string contactName);
    }
}
