using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_DL_Wrapper.Context
{
    /// <summary>
    /// Class containing arguments that can be passed to the youtube-dl binary.
    /// </summary>
    public class BinaryArguments
    {
        /// <summary>
        /// File format of the downloaded audio file.
        /// </summary>
        /// <remarks>If null or empty, no audio file created.</remarks>
        public string? AudioFormat { get; set; }

        /// <summary>
        /// Returns a string of arguments that can be passed to the youtube-dl binary.
        /// </summary>
        /// <returns>A string of arguments that can be passed to the youtube-dl binary.</returns>
        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
