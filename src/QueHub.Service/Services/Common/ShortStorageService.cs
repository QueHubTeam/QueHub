using QueHub.Service.Interfaces.Common;

namespace QueHub.Service.Services.Common;

public class ShortStorageService : IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
	public ShortStorageService()
	{
		KeyValuePairs = new Dictionary<string, string>();
	}
}
