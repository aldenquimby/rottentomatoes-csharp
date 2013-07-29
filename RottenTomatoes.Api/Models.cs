using System;
using System.Collections.Generic;

namespace RottenTomatoes.Api
{
    public class Movie
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Critics_Consensus { get; set; }
        public string MPAA_Rating { get; set; }
        public List<string> Genres { get; set; }
        public ReleaseDates Release_Dates { get; set; }
        public Ratings Ratings { get; set; }
        public string Synopsis { get; set; }
        public Posters Posters { get; set; }
        public string Studio { get; set; }
        public AlternateIds Alternate_Ids { get; set; }
        public List<Director> Abridged_Directors { get; set; }
        public List<CastMember> Abridged_Cast { get; set; }
        public MovieLinks Links { get; set; }

        // API sometimes sends back bad data for runtime, so treat as string and try parse it
        public string Runtime { private get; set; }
        public int? RuntimeInMinutes { get { int tmp; return int.TryParse(Runtime, out tmp) ? tmp : new int?(); } }
    }

    public class ReleaseDates
    {
        public DateTime? Theater { get; set; }
        public DateTime? DVD { get; set; }
    }

    public class Ratings
    {
        public string Critics_Rating { get; set; }
        public int? Critics_Score { get; set; }
        public string Audience_Rating { get; set; }
        public int? Audience_Score { get; set; }
    }

    public class Posters
    {
        public string Thumbnail { get; set; }
        public string Profile { get; set; }
        public string Detailed { get; set; }
        public string Original { get; set; }
    }

    public class AlternateIds
    {
        public string IMDB { get; set; }
    }

    public class Director
    {
        public string Name { get; set; }
    }

    public class CastMember
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public List<string> Characters { get; set; }
    }

    public class MovieLinks
    {
        public string Self { get; set; }
        public string Alternate { get; set; }
        public string Cast { get; set; }
        public string Clips { get; set; }
        public string Reviews { get; set; }
        public string Similar { get; set; }
        public string Canonical { get; set; }
    }

    public class Review
    {
        public string Critic { get; set; }
        public DateTime Date { get; set; }
        public string Original_Score { get; set; }
        public string Freshness { get; set; }
        public string Publication { get; set; }
        public string Quote { get; set; }
        public ReviewLinks Links { get; set; }
    }

    public class ReviewLinks
    {
        public string Review { get; set; }
        public string Publication { get; set; }
    }

    public class Clip
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Thumbnail { get; set; }
        public Links Links { get; set; }
    }

    public class Links
    {
        public string Self { get; set; } // url requested
        public string Next { get; set; } // next page url if paginating
        public string Alternate { get; set; } // alternate url for self
        public string Rel { get; set; } // related url, like movie if self is cast
    }
}