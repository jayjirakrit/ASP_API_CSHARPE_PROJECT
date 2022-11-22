﻿namespace NZWalks.API.Models.Entity
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        // Navigation Property
        public IEnumerable<Walk> Walks { get; set; }
    }
}
