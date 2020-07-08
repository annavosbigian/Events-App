using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RSVPTake3.Database;

//Uploads a photo for the invitation, renames photo when necessary. Delete removes folder from file

namespace RSVPTake3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UploadController : Controller
    {
        private string _folderName;
        public UploadController(IHostEnvironment env)
        {
            if (env.EnvironmentName == "Test")
            {
                this._folderName = Path.Combine("ClientApp", "dist", "assets", "img");

            }
            else
            {
                this._folderName = Path.Combine("ClientApp", "src", "assets", "img");
            }
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    var fullPath = Path.Combine(_folderName, fileName);

                    if (System.IO.File.Exists(fullPath))
                    {
                        int i = 1;
                        var tempName = fileName.Replace(".", i + ".");
                        while (System.IO.File.Exists(Path.Combine(_folderName, tempName)))
                        {
                            i++;
                            tempName = fileName.Replace(".", i + ".");
                        }
                        fullPath = Path.Combine(_folderName, tempName);
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        //DELETE: api/Upload/fileName
        [HttpDelete("{fileName}")]
        public IActionResult DeleteUpload(string fileName)
        {
            var fullPath = Path.Combine(this._folderName, fileName);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return Ok();
        }
    }


}