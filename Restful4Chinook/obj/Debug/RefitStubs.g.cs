﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using Refit;
using Restful4Chinook.Models;
using System.Threading.Tasks;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace Restful4Chinook.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

namespace Restful4Chinook.Interfaces
{
    using Restful4Chinook.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIchinookAPI : IchinookAPI
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIchinookAPI(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        public virtual Task<List<Artist>> GetAllArtists()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetAllArtists", new Type[] {  });
            return (Task<List<Artist>>)func(Client, arguments);
        }

        /// <inheritdoc />
        public virtual Task<Customer> GetCustomer(string email)
        {
            var arguments = new object[] { email };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetCustomer", new Type[] { typeof(string) });
            return (Task<Customer>)func(Client, arguments);
        }

        /// <inheritdoc />
        public virtual Task<List<Response1>> GetAlbumsOfArtist(string artistName)
        {
            var arguments = new object[] { artistName };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetAlbumsOfArtist", new Type[] { typeof(string) });
            return (Task<List<Response1>>)func(Client, arguments);
        }

        /// <inheritdoc />
        public virtual Task<List<Response2>> GetTracksOfAlbum(string albumName)
        {
            var arguments = new object[] { albumName };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetTracksOfAlbum", new Type[] { typeof(string) });
            return (Task<List<Response2>>)func(Client, arguments);
        }
    }
}
