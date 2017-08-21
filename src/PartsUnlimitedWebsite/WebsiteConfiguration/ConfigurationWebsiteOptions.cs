// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;

using System;

namespace PartsUnlimited.WebsiteConfiguration
{
    public class ConfigurationWebsiteOptions : IWebsiteOptions
    {
        public ConfigurationWebsiteOptions(IConfiguration config)
        {
            try
            {
                ShowRecommendations = Boolean.Parse(config["ShowRecommendations"]);
            }
            catch (InvalidCastException e)
            {
                
            }
        }

        public bool ShowRecommendations { get; }
    }
}