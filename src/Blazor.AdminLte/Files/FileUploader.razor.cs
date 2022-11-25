using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.AdminLte
{
    public partial class FileUploader
    {
        [Inject] 
        private IFilesManager FilesManager { get; set; }
        
        private bool isUploading = false;
        private string ErrorMessage = string.Empty;
        private string dropClass = string.Empty;
        private List<FileUploadProgress> _filesQueue = new();

        [Parameter]
        public EventCallback<UploadResultDto> OnUploadFinished { get; set; }

        [Parameter] 
        public int MaxAllowedFiles { get; set; } = 25;
        
        [Parameter]
        public long? MaximumFileSizeInBytes { get; set; }
        
        /// <summary>
        ///     Allowed extensions to upload. Must be specified with dot
        /// </summary>
        /// <example>
        ///     .json
        /// </example>
        [Parameter]
        public string[] AllowedExtensions { get; set; }

        private void AddFilesToQueue(InputFileChangeEventArgs e)
        {
            dropClass = string.Empty;
            ErrorMessage = string.Empty;

            if (e.FileCount > MaxAllowedFiles)
            {
                ErrorMessage = $"A maximum of {MaxAllowedFiles} is allowed, you have selected {e.FileCount} files!";
                return;
            }

            if (_filesQueue.Count > MaxAllowedFiles)
            {
                ErrorMessage = $"Queue already contains maximum number of items ({MaxAllowedFiles})! Clear the queue to continue.";
                return;
            }

            var files = e.GetMultipleFiles(MaxAllowedFiles);
            var fileCount = _filesQueue.Count;
            
            // Validate allowed extensions
            if (AllowedExtensions?.Any() == true)
            {
                var filesValid =
                    files.All(x => AllowedExtensions.Any(
                        ext => string.Equals(ext, Path.GetExtension(x.Name), StringComparison.InvariantCultureIgnoreCase)));

                if (!filesValid)
                {
                    ErrorMessage = $"Uploaded file(s) has invalid extension. Allowed extensions: {string.Join(", ", AllowedExtensions)}.";
                    return;
                }
            }

            if (MaximumFileSizeInBytes.HasValue &&
                files.Any(x => x.Size > MaximumFileSizeInBytes))
            {
                ErrorMessage = $"Reached maximum file size! Please select file(s) smaller than {ToReadableUnits()}";
                return;
            }
            
            foreach (var file in files)
            {
                var progress = new FileUploadProgress(file, file.Name, file.Size, fileCount);
                _filesQueue.Add(progress);
                fileCount++;
            }
        }

        private string ToReadableUnits()
        {
            var kb = Math.Round(MaximumFileSizeInBytes.Value / 1024.00);

            // TODO: Convert to MB if too big
            return $"{kb} kB";
        }

        private async Task UploadFileQueue()
        {
            isUploading = true;
            await InvokeAsync(StateHasChanged);

            foreach (var file in _filesQueue.OrderByDescending(x => x.FileId))
            {
                if (!file.HasBeenUploaded)
                {
                    await UploadChunks(file);
                    file.HasBeenUploaded = true;
                    if (OnUploadFinished.HasDelegate)
                    {
                        await OnUploadFinished.InvokeAsync(new UploadResultDto
                        {
                            FileName = file.FileName,
                            Uid = file.Uid
                        });
                    }
                }
            }

            isUploading = false;
        }

        private async Task UploadChunks(FileUploadProgress file)
        {
            var totalBytes = file.Size;
            long chunkSize = 400000;
            long numChunks = totalBytes / chunkSize;
            long remainder = totalBytes % chunkSize;

            string nameOnly = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            string newFileNameWithoutPath = $"{DateTime.Now.Ticks}-{nameOnly}{extension}";

            bool firstChunk = true;
            using (var inStream = file.FileData.OpenReadStream(long.MaxValue))
            {
                for (int i = 0; i < numChunks; i++)
                {
                    var buffer = new byte[chunkSize];
                    await inStream.ReadAsync(buffer, 0, buffer.Length);

                    var chunk = new ChunkedDataRequestDto
                    {
                        Data = buffer,
                        FileName = newFileNameWithoutPath,
                        Offset = _filesQueue[file.FileId].UploadedBytes,
                        FirstChunk = firstChunk,
                        Uid = file.Uid
                    };

                    await FilesManager.UploadFileChunkAsync(chunk);
                    firstChunk = false;

                    // Update our progress data and UI
                    _filesQueue[file.FileId].UploadedBytes += chunkSize;
                    await InvokeAsync(StateHasChanged);
                }

                if (remainder > 0)
                {
                    var buffer = new byte[remainder];
                    await inStream.ReadAsync(buffer, 0, buffer.Length);

                    var chunk = new ChunkedDataRequestDto
                    {
                        Data = buffer,
                        FileName = newFileNameWithoutPath,
                        Offset = _filesQueue[file.FileId].UploadedBytes,
                        FirstChunk = firstChunk,
                        Uid = file.Uid
                    };
                    
                    await FilesManager.UploadFileChunkAsync(chunk);

                    // Update our progress data and UI
                    _filesQueue[file.FileId].UploadedBytes += remainder;
                    await InvokeAsync(StateHasChanged);
                }
            }
        }

        private void RemoveFromQueue(int fileId)
        {
            var itemToRemove = _filesQueue.SingleOrDefault(x => x.FileId == fileId);
            if (itemToRemove != null)
            {
                _filesQueue.Remove(itemToRemove);
            }
        }

        public void ClearFileQueue()
        {
            _filesQueue.Clear();
        }       

        public record FileUploadProgress(IBrowserFile File, string FileName, long Size, int FileId)
        {
            public IBrowserFile FileData { get; set; } = File;
            public int FileId { get; set; } = FileId;
            public long UploadedBytes { get; set; }
            public double UploadedPercentage => (double)UploadedBytes / (double)Size * 100d;
            public bool HasBeenUploaded { get; set; } = false;
            public Guid Uid { get; set; } = Guid.NewGuid();
        }

        private void HandleDragEnter()
        {
            dropClass = "dropzone-active";
        }
        
        private void HandleDragLeave()
        {
            dropClass = string.Empty;
        }

        /*
        protected override async Task OnInitializedAsync()
        {
            await ListFiles();
        }

        private async Task ListFiles()
        {
            FileUrls = await FilesManager.GetFileNames();
            await InvokeAsync(StateHasChanged);
        }
        */
    }
}
