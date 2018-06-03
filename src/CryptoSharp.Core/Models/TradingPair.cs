using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CrypTrend.Core.Models
{

    public class TradingPair
    {

        private string _base;
        private string _quote;
        private string _toString;

        public string Base { get { return _base; } }
        public string Quote { get { return _quote; } }

        [JsonConstructor]
        public TradingPair(string @base, string quote)
        {
            if (string.IsNullOrWhiteSpace(@base)) throw new ArgumentNullException("@base");
            if (string.IsNullOrWhiteSpace(quote)) throw new ArgumentNullException("quote");

            _base = @base.ToUpper();
            _quote = quote.ToUpper();
        }

        public static TradingPair Create(string @base, string quote)
        {
            return new TradingPair(@base, quote);
        }

        public static TradingPair Create(string traindingPair, TradingPairFormatOption option = TradingPairFormatOption.BaseFirstDash)
        {

            var split = new List<string>();

            traindingPair = traindingPair.ToLower();

            if ((option & TradingPairFormatOption.XBT) == TradingPairFormatOption.XBT)
            {
                var regex = new Regex("(?i)btc(?-i)");
                traindingPair = regex.Replace(traindingPair, "xbt");
            }

            if ((option & TradingPairFormatOption.Dash) == TradingPairFormatOption.Dash)
            {
                traindingPair.Split("-").ToList().ForEach(split.Add);
            }
            else if ((option & TradingPairFormatOption.LowDash) == TradingPairFormatOption.LowDash)
            {
                traindingPair.Split("_").ToList().ForEach(split.Add);
            }

            if ((option & TradingPairFormatOption.QuoteFist) == TradingPairFormatOption.QuoteFist)
                return new TradingPair(split.LastOrDefault(), split.FirstOrDefault());
            else
                return new TradingPair(split.FirstOrDefault(), split.LastOrDefault());

        }

        public override string ToString()
        {
            return $"{_base}-{_quote}";
        }

        public string ToString(TradingPairFormatOption option)
        {

            string template = "{0}{1}";
            string result = "";
            if ((option & TradingPairFormatOption.Dash) == TradingPairFormatOption.Dash)
            {
                template = "{0}-{1}";
            }
            else if ((option & TradingPairFormatOption.LowDash) == TradingPairFormatOption.LowDash)
            {
                template = "{0}_{1}";
            }

            result =
                (option & TradingPairFormatOption.QuoteFist) == TradingPairFormatOption.QuoteFist ?
                string.Format(template, _quote, _base) :
                string.Format(template, _base, _quote);

            if ((option & TradingPairFormatOption.XBT) == TradingPairFormatOption.XBT)
            {
                var regex = new Regex("(?i)btc(?-i)");
                result = regex.Replace(result, "xbt");
            }

            result =
                (option & TradingPairFormatOption.LowerCase) == TradingPairFormatOption.LowerCase ?
                result.ToLower() :
                result.ToUpper();

            return result;

        }

    }

    [Flags]
    public enum TradingPairFormatOption
    {
        BaseFirst = 1,
        QuoteFist = 2,
        Dash = 4,
        BaseFirstDash = 5,
        QuoteFirstDash = 6,
        LowDash = 8,
        BaseFirstLowDash = 9,
        QuoteFirstLowDash = 10,
        LowerCase = 16,
        BaseFirstDashLowerCase = 21,
        QuoteFirstDashLowerCase = 22,
        BaseFirstLowDashLowerCase = 25,
        QuoteFirstLowDashLowerCase = 26,
        XBT = 32,
        LowerCaseXBT = 48,
        BaseFirstDashLowerCaseXBT = 53,
        QuoteFirstDashLowerCaseXBT = 54,
        BaseFirstLowDashLowerCaseXBT = 57,
        QuoteFirstLowDashLowerCaseXBT = 58,
    }

}