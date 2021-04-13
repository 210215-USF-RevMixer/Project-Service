﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ProjectREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleBlobController : ControllerBase
    {
        // POST api/SampleBlobConroller/5
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> PostSampleToStorageAsync()
        {
            var file = Request.Form.Files[0];
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string localPath = @"C:\local\Temp\" + Guid.NewGuid().ToString();
            string fileType = file.ContentType;
            string containerEndpoint = "https://revmixerstoragep3.blob.core.windows.net/uploadsample";
            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint), new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true }));
            try
            {
                //create container if it does not exists
                await containerClient.CreateIfNotExistsAsync();

                if (file.Length > 0)
                {
                    using (var stream = System.IO.File.Create(localPath))
                    {
                        file.CopyTo(stream);
                        stream.Position = 0;

                        containerClient.UploadBlob(fileName, stream);

                        var blob = containerClient.GetBlobClient(fileName);

                        stream.Position = 0;
                        blob.Upload(
                            stream,
                            new BlobHttpHeaders
                            {
                                ContentType = fileType
                            },
                            conditions: null);
                        //Log.Logger.Information($"File {fileName} uploaded to azure blob storage");
                    }
                }
                return Ok(new { name = fileName, songname = file.FileName });
            }
            catch (Exception e)
            {
                return Ok(new { error = e.Message });
            }
        }
    }
}
