// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        private ITelemetryProvider _telemetry;

        public SearchController(IProductSearch search, ITelemetryProvider telemetryProvider)
        {
            _search = search;
            _telemetry = telemetryProvider;
        }

        public async Task<IActionResult> Index(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return View(null);
            }


            // Telemetry Exercise:  start timer here
            var startTime = System.DateTime.Now;

            var result = await _search.Search(q);

            // Telemetry Exercise: stop timer here & compute difference
            var measurements = new Dictionary<string, double>()
            {
                {"SearchTimeInMilliseconds", System.DateTime.Now.Subtract(startTime).TotalMilliseconds }
            };

            // Telemetry Exercise: collect telemetry data
            _telemetry.TrackEvent("Search/Server/Run", null, measurements);

            return View(result);
        }
    }
}
