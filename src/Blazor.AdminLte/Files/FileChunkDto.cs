using System;

namespace Blazor.AdminLte
{
    public class ChunkedDataRequestDto
    {
        public string FileName { get; set; } = "";
        public long Offset { get; set; }
        public byte[] Data { get; set; }
        public bool FirstChunk = false;
        public Guid Uid { get; set; }
    }
}
