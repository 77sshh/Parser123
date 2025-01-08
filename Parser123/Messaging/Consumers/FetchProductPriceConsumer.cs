using MassTransit;
using Microsoft.EntityFrameworkCore;
using Parser123.Data;
using Parser123.Data.ParseLog;
using Parser123.Messaging.Messages;
using Parser123.Services;

namespace Parser123.Messaging.Consumers;

public class FetchProductPriceConsumer(AppDbContext dbContext, PriceFetcher priceFetcher): IConsumer<FetchProductPriceMessage>
{
	public async Task Consume(ConsumeContext<FetchProductPriceMessage> context)
	{
		var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == context.Message.ProductId);
		if (product is null)
			return;

		var prices = await Task.WhenAll([
			priceFetcher.FetchPriceAsync(product.DomotexLink, WebShop.Domotex),
			priceFetcher.FetchPriceAsync(product.VodoparadLink, WebShop.Vodoparad)
		]);

		if (prices.Any(p => !p.HasValue))
			return;

		var parseLog = new ParseLog(DateTime.Now, prices[0]!.Value, prices[1]!.Value, product);
		dbContext.ParseLogs.Add(parseLog);
		await dbContext.SaveChangesAsync();
	}
}