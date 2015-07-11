﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieReview.Web
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
			config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "ApiControllerOnly",
				routeTemplate: "api/{controller}");

			config.Routes.MapHttpRoute(
				name: "ApiControllerAndIntegerId",
				routeTemplate: "api/{controller}/{id}",
				defaults: null,
				constraints: new { id = @"^\d+$" }
				);

			config.Routes.MapHttpRoute(
				name: "ApiControllerAction",
				routeTemplate: "api/{controller}/{action}"
				);
		}
	}
}