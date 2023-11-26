//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Core.Environments.Client.Http;



namespace Unity.Services.Core.Environments.Client.Models
{
    /// <summary>
    /// UnityGetOrganizationMembers200Response model
    /// </summary>
    [Preserve]
    [DataContract(Name = "unity_getOrganizationMembers_200_response")]
    internal class UnityGetOrganizationMembers200Response
    {
        /// <summary>
        /// Creates an instance of UnityGetOrganizationMembers200Response.
        /// </summary>
        /// <param name="offset">Offset used by the request.</param>
        /// <param name="limit">Limit used by the request.</param>
        /// <param name="total">The total number of items matched by the request.</param>
        /// <param name="results">results param</param>
        [Preserve]
        public UnityGetOrganizationMembers200Response(int offset = default, int limit = default, int total = default, List<UnityOrganizationMemberV1> results = default)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
            Results = results;
        }

        /// <summary>
        /// Offset used by the request.
        /// </summary>
        [Preserve]
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int Offset{ get; }
        
        /// <summary>
        /// Limit used by the request.
        /// </summary>
        [Preserve]
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int Limit{ get; }
        
        /// <summary>
        /// The total number of items matched by the request.
        /// </summary>
        [Preserve]
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total{ get; }
        
        /// <summary>
        /// Parameter results of UnityGetOrganizationMembers200Response
        /// </summary>
        [Preserve]
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<UnityOrganizationMemberV1> Results{ get; }
    
        /// <summary>
        /// Formats a UnityGetOrganizationMembers200Response into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "offset," + Offset.ToString() + ",";
            serializedModel += "limit," + Limit.ToString() + ",";
            serializedModel += "total," + Total.ToString() + ",";
            if (Results != null)
            {
                serializedModel += "results," + Results.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a UnityGetOrganizationMembers200Response as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var offsetStringValue = Offset.ToString();
            dictionary.Add("offset", offsetStringValue);
            
            var limitStringValue = Limit.ToString();
            dictionary.Add("limit", limitStringValue);
            
            var totalStringValue = Total.ToString();
            dictionary.Add("total", totalStringValue);
            
            return dictionary;
        }
    }
}
