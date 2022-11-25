using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public interface IFilesManager
    {
        Task<bool> UploadFileChunkAsync(ChunkedDataRequestDto fileChunkDto);
        Task<List<string>> GetFileNamesAsync();
    }
}
