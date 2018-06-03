using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoSharp.ClientGenerator
{
    public class SwaggerSettings
    {
        public ExchangeSettings[] ExchangeSettings { get; set; }
        public string Test { get; set; }
    }


    public class ExchangeSettings
    {
        public string ExchangeName { get; set; }
        public string SwaggerFileUrl { get; set; }
    }
}