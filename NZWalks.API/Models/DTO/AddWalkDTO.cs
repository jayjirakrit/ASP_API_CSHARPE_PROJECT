﻿using NZWalks.API.Models.Entity;

namespace NZWalks.API.Models.DTO
{
    public class AddWalkDTO
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
