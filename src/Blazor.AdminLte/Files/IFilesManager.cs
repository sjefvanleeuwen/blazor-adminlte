

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public interface IFilesManager
    {
        Task<bool> UploadFileChunk(ChunkedDataRequestDto fileChunkDto);
        Task<List<string>> GetFileNames();
    }
}
