using System.Collections.Generic;

namespace RottenTomatoes.Api
{
    public abstract class ResponseBase
    {
        public string Error { get; set; }
    }

    public class MoviesResponse : ResponseBase
    {
        public int? Total { get; set; }
        public List<Movie> Movies { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
    }

    public class CastResponse : ResponseBase
    {
        public List<CastMember> Cast { get; set; }
        public Links Links { get; set; }
    }

    public class ClipsResponse : ResponseBase
    {
        public List<Clip> Clips { get; set; }
        public Links Links { get; set; }
    }

    public class ReviewsResponse : ResponseBase
    {
        public int? Total { get; set; }
        public List<Review> Reviews { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
    }
}