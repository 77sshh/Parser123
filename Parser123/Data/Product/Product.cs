namespace Parser123.Data.Product;

public class Product
{
	private Product() { }

	public Product(string name, string domotexLink, string vodoparadLink)
	{
		this.Name = name;
		this.DomotexLink = domotexLink;
		this.VodoparadLink = vodoparadLink;
	}

	public Guid Id { get; private set; }
	public string Name { get; private set; } = null!;
	public string DomotexLink { get; private set; } = null!;
	public string VodoparadLink { get; private set; } = null!;

	public List<ParseLog.ParseLog> Logs { get; private set; } = [];
}