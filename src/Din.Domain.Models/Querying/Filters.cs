﻿namespace Din.Domain.Models.Querying
{
    public class Filters
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public bool? Downloaded { get; set; }
        public string Year { get; set; }
    }
}