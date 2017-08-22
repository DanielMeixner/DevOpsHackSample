// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using PartsUnlimited.Search;
using PartsUnlimited.Telemetry;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartsUnlimited.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductSearch _search;

        // Telemetry Exercise: create Telemetry Client here        
         private TelemetryClient appInsights = new TelemetryClient();



        public SearchController(IProductSearch search)
        {
            _search = search;
            
        }

        public async Task<IActionResult> Index(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return View(null);
            }

            appInsights.TrackTrace("Someone calling search...", null);
            // Telemetry Exercise:  start timer here
            
            var result = await _search.Search(q);

            // Telemetry Exercise: stop timer here & compute difference
            

            // Telemetry Exercise: collect telemetry data
            

            return View(result);
        }
    }
}
