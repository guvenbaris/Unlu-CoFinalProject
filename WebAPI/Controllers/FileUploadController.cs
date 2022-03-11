using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using UnluCoProductCatalog.Application.ViewModels.UploadedViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadController
            (IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public void Upload(UploadedViewModel uploadViewModel)
        {
            var path = $"{_env.WebRootPath}\\{uploadViewModel.FileName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(uploadViewModel.FileContent, 0,
                uploadViewModel.FileContent.Length);
            fileStream.Close();
        }
    }
}

