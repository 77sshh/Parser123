using System.Text.RegularExpressions;

namespace Parser123.Services;

public partial class PriceFetcher(IHttpClientFactory httpClientFactory)
{
	public async Task<double?> FetchPriceAsync(string url, WebShop shop)
	{
		var httpClient = httpClientFactory.CreateClient();
		var response = await httpClient.GetAsync(url);
		var body = await response.Content.ReadAsStringAsync();

		var regex = shop switch
		{
			WebShop.Domotex => DomotexRegex(),
			WebShop.Vodoparad => VodopadRegex(),
			_ => throw new ArgumentOutOfRangeException(nameof(shop), shop, null)
		};
		var match = regex.Match(body);
		if (match.Success && double.TryParse(match.Groups[1].Value, out var price))
			return price;

		return null;
	}


	[GeneratedRegex(@"'VALUE_VAT':'(\d+)'")]
	private static partial Regex DomotexRegex();

	[GeneratedRegex("""
	                data-price="(\d+)"
	                """)]
	private static partial Regex VodopadRegex();
}

public enum WebShop
{
	Domotex,
	Vodoparad
}