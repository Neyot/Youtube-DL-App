using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youtube_DL_Wrapper.Context;

namespace Youtube_DL_Wrapper.Interfaces
{
    /// <summary>
    /// Service managing the download of files using the youtube-dl binary.
    /// </summary>
    public interface IDownloadService
    {
        /// <summary>
        /// Event raised when a current download progresses.
        /// </summary>
        event EventHandler DownloadProgressEvent;

        /// <summary>
        /// Download a file from the specified URL, using the specified binary, to a specified output path, using the specified arguments.
        /// </summary>
        /// <param name="url">File URL to download.</param>
        /// <param name="binaryPath">Binary used to download file.</param>
        /// <param name="outputPath">Path to output downloaded file to.</param>
        /// <param name="arguments">Arguments used to configure download and outputted file.</param>
        /// <param name="result">Downloaded file; <see langword="null"/> if download failed.</param>
        /// <returns><see langword="true"/> if the download succeeded; otherwise, <see langword="false"/>.</returns>
        bool TryDownload(string url, string binaryPath, string outputPath, BinaryArguments arguments, out FileInfo result);
    }
}
