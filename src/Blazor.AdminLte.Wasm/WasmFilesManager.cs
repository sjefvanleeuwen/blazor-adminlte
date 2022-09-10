using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace Blazor.AdminLte
{
    public class WasmFilesManager : IFilesManager
    {
        HttpClient _http;
        public WasmFilesManager(HttpClient http)
        {
            _http = http;
        } //FilesManager


        public async Task<bool> UploadFileChunk(ChunkedDataRequestDto fileChunkDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/Files/UploadFileChunk", fileChunkDto);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                return Convert.ToBoolean(responseBody);
            }
            catch (Exception ex)
            {
                return false;
            }
        } //UploadFileChunk


        public async Task<List<string>> GetFileNames()
        {
            try
            {
                var response = await _http.GetAsync("api/Files/GetFiles");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<string>>(responseBody);
            }
            catch (Exception ex)
            {
                return null;
            }
        } //GetFileNames
    }
}
