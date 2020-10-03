using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nudes.Retornator.Core
{
    public class StreamResult : BaseResult<StreamResult>
    {
        public Stream Stream { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; } = "application/octet-stream";
    }
}
