using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_DL_Wrapper.Context
{
    /// <summary>
    /// Class containing arguments specific to downloading audio files from the binary.
    /// </summary>
    public class AudioDownloadArguments : BinaryArguments
    {
        /// <summary>
        /// Initialises a new instance of the Audio-Download Arguments class.
        /// </summary>
        /// <param name="audioFileExtension">File extension of outputted audio file.</param>
        public AudioDownloadArguments(string audioFileExtension)
        {
            this.AudioFormat = audioFileExtension;
        }
    }
}
