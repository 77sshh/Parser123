using System.ComponentModel.DataAnnotations;

namespace Parser123.Models;

public class AddItemModel
{
	[Required(ErrorMessage = "Имя товара обязательно")]
	public string Name { get; set; } = "";

	[Required(ErrorMessage = "Ссылка на товар в Водопараде обязательна")]
	[RegularExpression(@"^https://([\w-]+\.)*vodoparad\.ru(/.*)?$",
		ErrorMessage = "Ссылка на товар в Водопараде должна начинаться с 'https://' и содержать 'vodoparad.ru'")]
	public string Vodoparad { get; set; } = "";

	[Required(ErrorMessage = "Ссылка на товар в Домотексе обязательна")]
	[RegularExpression(@"^https://([\w-]+\.)*domotex\.ru(/.*)?$",
		ErrorMessage = "Ссылка на товар в Domotex должна начинаться с 'https://' и содержать 'domotex.ru'")]
	public string DomotexLink { get; set; } = "";
}