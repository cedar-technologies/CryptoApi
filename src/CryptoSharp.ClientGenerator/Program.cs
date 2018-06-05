using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace CryptoSharp.ClientGenerator
{
    public class Program
    {

        private static string _generatedDirectory = $"{Directory.GetCurrentDirectory()}/Generated";

        static void Main(string[] args)
        {
            GetConfiguration().ExchangeSettings.ToList().ForEach(GenerateCode);
            
        }

        private static void GenerateCode(ExchangeSettings exchangeSettings)
        {
            try
            {

                Console.WriteLine($"Generating Documentation for {exchangeSettings.ExchangeName}");
                var document =
                    SwaggerYamlDocument.FromUrlAsync(exchangeSettings.SwaggerFileUrl).Result;

                var settings = new SwaggerToCSharpClientGeneratorSettings
                {
                    ClassName = $"{exchangeSettings.ExchangeName}Client",
                    CSharpGeneratorSettings =
                    {
                        Namespace = $"CryptoSharp.Client.Exchanges.{exchangeSettings.ExchangeName}",
                        SchemaType = SchemaType.OpenApi3,
                        ClassStyle = CSharpClassStyle.Poco,
                        
                       
                    },
                    GenerateClientInterfaces = true,
                    CodeGeneratorSettings = { SchemaType = SchemaType.OpenApi3},
                    
                };

                


                var generator = new SwaggerToCSharpClientGenerator(document, settings);
                var code = generator.GenerateFile();

                // hack to replace double by decimal
                var regex = new Regex("\\sdouble\\s", RegexOptions.Multiline);

                code = regex.Replace(code, " decimal ");

                if (!Directory.Exists(_generatedDirectory))
                    Directory.CreateDirectory(_generatedDirectory);

                File.WriteAllText($"{ _generatedDirectory}/{exchangeSettings.ExchangeName}Client.cs", code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static SwaggerSettings GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
        }
    }
}