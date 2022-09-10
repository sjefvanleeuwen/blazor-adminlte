
using System;

namespace Blazor.AdminLte
    {
        public class TrackCardState
        {
            public string ArtistName { get; set; }
            public string Title { get; set; }

            public string AvatarImageUrl { get; set; }
            public string CoverImageUrl { get; set; }
            public string ContentUrl { get; set; }
            public int Likes { get; set; }
            public int Reviews { get; set; }
            public int Plays { get; set; }
            public TimeSpan ContentLength { get; set; }
            public double ContentBpm { get; set; }
        }
    }

