using HtmlAgilityPack;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Interface
{
    public interface IScraper
    {
        Task<string> GetStringAsync();
        Task<HtmlNode> GetDocumentAsync();
        
    }
}
