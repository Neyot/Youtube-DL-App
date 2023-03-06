using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_DL_Wrapper.Interfaces
{
    /// <summary>
    /// Service managing locating and serving the location of the youtube-dl binary.
    /// </summary>
    public interface IBinaryService
    {
        /// <summary>
        /// Gets the path of the youtube-dl binary.
        /// </summary>
        string BinaryPath { get; }

        /// <summary>
        /// Gets a value indicating whether the binary exists and is valid at the <see cref="BinaryPath"/>.
        /// </summary>
        bool IsBinaryPathValid { get; }

        /// <summary>
        /// Try to set the binary path to a specific file/directory path.
        /// </summary>
        /// <remarks>Used to set a user-specified path as opposed to using the automatically located path.</remarks>
        /// <param name="path">File path of binary or directory containing binary.</param>
        /// <returns><see langword="true"/> if the binary exists and is valid; otherwise, <see langword="false"/>.</returns>
        bool TrySetBinaryPath(string path);
    }
}
