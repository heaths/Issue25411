// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Jobs
{
    /// <summary> Client options for JobsClient. </summary>
    public partial class JobsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_11_18;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2021-11-18". </summary>
            V2021_11_18 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of JobsClientOptions. </summary>
        public JobsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_11_18 => "2021-11-18",
                _ => throw new NotSupportedException()
            };
        }
    }
}
