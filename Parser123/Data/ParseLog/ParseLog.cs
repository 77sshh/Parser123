namespace Parser123.Data.ParseLog;

public class ParseLog
{
	private ParseLog() {}


	public ParseLog(DateTime date, double domotexPrice, double vodoparadPrice, Product.Product product)
	{
		this.Date = date;
		this.DomotexPrice = domotexPrice;
		this.VodoparadPrice = vodoparadPrice;
		this.Product = product;
	}

	public Guid Id { get; private set; }
	public DateTime Date { get; private set; }
	public double DomotexPrice { get; private set; } 
	public double VodoparadPrice { get; private set; } 

	public Product.Product Product { get; private set; } = null!;
}