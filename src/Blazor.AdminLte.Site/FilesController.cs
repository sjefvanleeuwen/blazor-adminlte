using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Blazor.AdminLte.Site
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase, IFilesManager
    {
        public FilesController()
        {
        } //FilesController


        [HttpPost("UploadFileChunk")]
        public Task<bool> UploadFileChunkAsync([FromBody] ChunkedDataRequestDto chunkedDataRequestDto)
        {
            try
            {
                // get the local filename
                string filePath = Environment.CurrentDirectory + "\\StaticFiles\\";
                string fileName = filePath + chunkedDataRequestDto.FileName;

                // delete the file if necessary
                if (chunkedDataRequestDto.FirstChunk && System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);

                // open for writing
                using (var stream = System.IO.File.OpenWrite(fileName))
                {
                    stream.Seek(chunkedDataRequestDto.Offset, SeekOrigin.Begin);
                    stream.Write(chunkedDataRequestDto.Data, 0, chunkedDataRequestDto.Data.Length);
                }

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return Task.FromResult(false);
            }
        } //UploadFileChunk


        [HttpGet("GetFiles")]
        public Task<List<string>> GetFileNamesAsync()
        {
            var result = new List<string>();
            var files = Directory.GetFiles(Environment.CurrentDirectory + "\\StaticFiles", "*.*");
            foreach (var file in files)
            {
                var justTheFileName = Path.GetFileName(file);
                result.Add($"files/{justTheFileName}");
            }

            return Task.FromResult(result);
        } //GetFiles
    }
}
