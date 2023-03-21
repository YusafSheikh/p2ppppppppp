using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CentralizedServer.Controllers
{
    public class FileEndPoint
    {
        public string IPAddress { get; set; }
        public int PortNumber { get; set; }
    }

    public class FilesController : ControllerBase
    {
        private static readonly Dictionary<string, List<FileEndPoint>> fileDictionary = new Dictionary<string, List<FileEndPoint>>();

        [HttpGet]
        public IEnumerable<string> GetAllFilenames()
        {
            return fileDictionary.Keys;
        }

        [HttpGet("{filename}")]
        public IEnumerable<FileEndPoint> GetPeersForFilename(string filename)
        {
            if (fileDictionary.ContainsKey(filename))
            {
                return fileDictionary[filename];
            }
            else
            {
                return Enumerable.Empty<FileEndPoint>();
            }
        }

        [HttpPost("{filename}")]
        public IActionResult RegisterFile(string filename, [FromBody] FileEndPoint endPoint)
        {
            if (!fileDictionary.ContainsKey(filename))
            {
                fileDictionary.Add(filename, new List<FileEndPoint>());
            }

            if (!fileDictionary[filename].Contains(endPoint))
            {
                fileDictionary[filename].Add(endPoint);
            }

            return Ok();
        }

        [HttpPut("{filename}")]
        public IActionResult DeleteFileEndPoint(string filename, [FromBody] FileEndPoint endPoint)
        {
            if (fileDictionary.ContainsKey(filename))
            {
                fileDictionary[filename].Remove(endPoint);
            }

            return Ok();
        }
    }
}
