using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_DL_Wrapper.Interfaces;

namespace Youtube_DL_Wrapper.Services
{
    /// <summary>
    /// Helper service to aid locating and validating the youtube-dl binary.
    /// </summary>
    public class BinaryHelper : IBinaryHelper
    {
        /// <inheritdoc/>
        public string? BinaryPath { get; set; }

        /// <inheritdoc/>
        public bool IsBinaryPathValid => throw new NotImplementedException();

        /// <inheritdoc/>
        public bool TrySetBinaryPath(string? path)
        {
            // TODO: Check if path is valid instance of youtube-dl.

            if (File.Exists(path) && Path.GetExtension(path) == ".exe")
            {
                this.BinaryPath = path;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
