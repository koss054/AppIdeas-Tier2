﻿using BookFinder.Server.Models.Books;

namespace BookFinder.Server.Models
{
    public class VolumeInfo
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public List<string> Authors { get; set; } = [];
        public string? Publisher { get; set; }
        public string? PublishedDate { get; set; }
        public string? Description { get; set; }
        public int PageCount { get; set; }
        public List<string> Categories { get; set; } = [];
        public ImageLinks ImageLinks { get; set; } = new();
    }
}
