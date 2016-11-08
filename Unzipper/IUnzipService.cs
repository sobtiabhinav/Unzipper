// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnzipService.cs" company="">
//   
// </copyright>
// <summary>
//   The UnzipService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Unzipper
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    /// The UnzipService interface.
    /// </summary>
    [ServiceContract]
    public interface IUnzipService
    {
        // [OperationContract]
        // string GetData(int value);

        // [OperationContract]
        // CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        /// <summary>
        /// The get unzipped files.
        /// </summary>
        /// <param name="zipPath">
        /// The zip path.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        [OperationContract]
        Dictionary<string, byte[]> GetUnzippedFiles(string zipPath);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    /// <summary>
    /// The composite type.
    /// </summary>
    [DataContract]
    public class CompositeType
    {
        /// <summary>
        /// The bool value.
        /// </summary>
        private bool boolValue = true;

        /// <summary>
        /// The string value.
        /// </summary>
        private string stringValue = "Hello ";

        /// <summary>
        /// Gets or sets a value indicating whether bool value.
        /// </summary>
        [DataMember]
        public bool BoolValue
        {
            get
            {
                return this.boolValue;
            }

            set
            {
                this.boolValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        [DataMember]
        public string StringValue
        {
            get
            {
                return this.stringValue;
            }

            set
            {
                this.stringValue = value;
            }
        }
    }
}