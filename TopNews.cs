using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Linq;

namespace SimpleNewsChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching top news...");

            try
            {
                // Example RSS feed from Reuters. Replace with your preferred news source.
                string url = "https://feeds.reuters.com/Reuters/worldNews";
                using (XmlReader reader = XmlReader.Create(url))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    Console.WriteLine("Top news headlines:");
                    foreach (SyndicationItem item in feed.Items.Take(5)) // Only take the top 5 news items for brevity
                    {
                        Console.WriteLine($"- {item.Title.Text}");
                        // Optionally, provide a link to the full news
                        Console.WriteLine($"  {item.Links[0].Uri}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("Done.");
        }
    }
}
