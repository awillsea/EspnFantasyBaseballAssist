using EspnScrapeV1._0.Models;
using EspnScrapeV1._0;
namespace EspnScrapeV1._0.Models
{
    public class TeamNames
    {
        public TeamNames() 
        {
            Name= Name;
            listOfNames = new List<string>();
        }
        public string Name { get; set; }
        public List<string> listOfNames { get; set; }
    }
    
}
