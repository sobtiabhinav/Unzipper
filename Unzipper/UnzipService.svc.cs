// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnzipService.svc.cs" company="">
//   
// </copyright>
// <summary>
//   The unzip service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Unzipper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    /// <summary>
    /// The unzip service.
    /// </summary>
    public class UnzipService : IUnzipService
    {
        /// <summary>
        /// The get unzipped files.
        /// </summary>
        /// <param name="zipPath">
        /// The zip path.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        public Dictionary<string, byte[]> GetUnzippedFiles(string zipPath)
        {
            var uri = new Uri(zipPath);
            WebClient wc = new WebClient();
            wc.DownloadFile(uri, @"D:/tempfile.zip");

            var path = Path.GetFullPath(@"D:/tempfile.zip");

            Dictionary<string, byte[]> dataDictionary = new Dictionary<string, byte[]>();

            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    var tempData = entry.Open();
                    dataDictionary.Add(entry.FullName, this.ReadFully(tempData));
                }
            }

            return dataDictionary;
        }

        /// <summary>
        /// The get data.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        /// <summary>
        /// The get data using data contract.
        /// </summary>
        /// <param name="composite">
        /// The composite.
        /// </param>
        /// <returns>
        /// The <see cref="CompositeType"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }

            return composite;
        }

        /// <summary>
        /// The read fully.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[Int16.MaxValue];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }
    }
}