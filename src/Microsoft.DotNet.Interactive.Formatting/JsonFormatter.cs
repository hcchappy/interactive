﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Interactive.Formatting
{
    public static class JsonFormatter
    {
        static JsonFormatter()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Newtonsoft.Json.Formatting.None
            };

        }

        public static ITypeFormatter GetBestFormatterFor(Type type)
        {
            return Formatter.GetBestFormatterFor(type, MimeType);
        }

        public static ITypeFormatter GetBestFormatterFor<T>() =>
            GetBestFormatterFor(typeof(T));

        public const string MimeType = "application/json";

        internal static ITypeFormatter[] DefaultFormatters { get; } = DefaultJsonFormatterSet.DefaultFormatters;

        public static JsonSerializerSettings SerializerSettings { get; }

    }
}