using System.Collections.Generic;

namespace YoutubeClient
{
    public class SearchItem
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public Id Id { get; set; }
    }

    public class Id
    {
        public string VideoId { get; set; }
    }
}