using System.Collections.Generic;

namespace RottenTomatoesApi
{
    public class MoviesResponse
    {
        public int Total { get; set; }
        public IList<Movie> Movies { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
    }

    public class CastResponse
    {
        public IList<CastMember> Cast { get; set; }
        public Links Links { get; set; }
    }

    public class ClipsResponse
    {
        public IList<Clip> Clips { get; set; }
        public Links Links { get; set; }
    }

    public class ReviewsResponse
    {
        public int Total { get; set; }
        public IList<Review> Reviews { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
    }
}