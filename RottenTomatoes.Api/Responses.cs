using System.Collections.Generic;

namespace RottenTomatoes.Api
{
    public interface IResponseBase
    {
        string Error { get; set; }
    }

    public class MovieResponse : Movie, IResponseBase
    {
        public string Error { get; set; }
    }

    public class MoviesResponse : IResponseBase
    {
        public int? Total { get; set; }
        public List<Movie> Movies { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
        public string Error { get; set; }
    }

    public class CastResponse : IResponseBase
    {
        public List<CastMember> Cast { get; set; }
        public Links Links { get; set; }
        public string Error { get; set; }
    }

    public class ClipsResponse : IResponseBase
    {
        public List<Clip> Clips { get; set; }
        public Links Links { get; set; }
        public string Error { get; set; }
    }

    public class ReviewsResponse : IResponseBase
    {
        public int? Total { get; set; }
        public List<Review> Reviews { get; set; }
        public Links Links { get; set; }
        public string Link_Template { get; set; }
        public string Error { get; set; }
    }
}