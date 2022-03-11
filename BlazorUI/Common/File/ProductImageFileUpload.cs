using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorUI.Common.File
{
    public class ProductImageFileUpload
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductImageFileUpload(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<string> UploadProductImage(MultipartFormDataContent content)
        {
            var client = _clientFactory.CreateClient();
            var postResult = await client.PostAsync("https://localhost:3000/api/Upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:3000/", postContent);
                return imgUrl;
            }
        }
    }
}
