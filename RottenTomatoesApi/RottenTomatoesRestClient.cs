﻿using System.Text;
using RestSharp;
using RestSharp.Extensions;

namespace RottenTomatoesApi
{
    public interface IRottenTomatoesRestClient
    {
        MoviesResponse MoviesSearch(string query, int pageLimit = 30, int page = 1);
        Movie MovieInfo(long movieId);
        Movie MovieAlias(string id, AliasType type = AliasType.IMDB);
        ReviewsResponse MovieReviews(long movieId, ReviewType type = ReviewType.Top_Critic, int pageLimit = 20, int page = 1, string country = "us");
        MoviesResponse MovieSimilar(long movieId, int limit = 5);
        ClipsResponse MovieClips(long movieId);
        CastResponse MovieCast(long movieId);
        MoviesResponse BoxOfficeMovies(int limit = 10, string country = "us");
        MoviesResponse InTheatersMovies(int pageLimit = 16, int page = 1, string country = "us");
        MoviesResponse OpeningMovies(int limit = 16, string country = "us");
        MoviesResponse UpcomingMovies(int pageLimit = 16, int page = 1, string country = "us");
        MoviesResponse TopRentals(int limit = 10, string country = "us");
        MoviesResponse CurrentReleaseDvds(int pageLimit = 16, int page = 1, string country = "us");
        MoviesResponse NewReleaseDvds(int pageLimit = 16, int page = 1, string country = "us");
        MoviesResponse UpcomingDvds(int pageLimit = 16, int page = 1, string country = "us");
    }

    public class RottenTomatoesRestClient : IRottenTomatoesRestClient
    {
        private readonly IRestClient _client;

        public RottenTomatoesRestClient(string apiKey)
        {
            _client = new RestClient
            {
                UserAgent = "rotten-tomatoes-csharp",
                BaseUrl = @"http://api.rottentomatoes.com/api/public/v1.0",

                // authenticate via URL
                // Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken),
            };

            _client.AddDefaultHeader("Accept-charset", "utf-8");
            _client.AddDefaultParameter("apiKey", apiKey);
        }

        private T Execute<T>(IRestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = resp =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if ((int)resp.StatusCode >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    const string restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);
                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson);
                }
            };

            var response = _client.Execute<T>(request);
            return response.Data;
        }

        private IRestRequest CreateRequest(string resource, object urlSegments = null, object urlParams = null)
        {
            var request = new RestRequest(resource);

            if (urlSegments != null)
            {
                foreach (var prop in urlSegments.GetType().GetProperties())
                {
                    request.AddUrlSegment(prop.Name, prop.GetValue(urlSegments).ToString());
                }
            }

            if (urlParams != null)
            {
                foreach (var prop in urlParams.GetType().GetProperties())
                {
                    request.AddParameter(prop.Name, prop.GetValue(urlParams));
                }
            }

            return request;
        }

        public MoviesResponse MoviesSearch(string query, int pageLimit = 30, int page = 1)
        {
            var urlParams = new {q = query, page_limit = pageLimit, page};

            var request = CreateRequest("movies.json", urlParams: urlParams);
            
            return Execute<MoviesResponse>(request);
        }

        public Movie MovieInfo(long movieId)
        {
            var request = CreateRequest("movies/{movieId}.json", new {movieId});
            
            return Execute<Movie>(request);
        }

        public Movie MovieAlias(string id, AliasType type = AliasType.IMDB)
        {
            var urlParams = new {id, type = type.ToString().ToLower()};

            var request = CreateRequest("movie_alias.json", urlParams: urlParams);

            return Execute<Movie>(request);
        }

        public ReviewsResponse MovieReviews(long movieId, ReviewType type = ReviewType.Top_Critic, int pageLimit = 20, int page = 1, string country = "us")
        {
            var urlParams = new {review_type = type.ToString().ToLower(), page_limit = pageLimit, page, country};

            var request = CreateRequest("movies/{movieId}/reviews.json", new { movieId }, urlParams);

            return Execute<ReviewsResponse>(request);
        }

        public MoviesResponse MovieSimilar(long movieId, int limit = 5)
        {
            var request = CreateRequest("movies/{movieId}/similar.json", new {movieId}, new {limit});

            return Execute<MoviesResponse>(request);
        }

        public ClipsResponse MovieClips(long movieId)
        {
            var request = CreateRequest("movies/{movieId}/clips.json", new { movieId });

            return Execute<ClipsResponse>(request);
        }

        public CastResponse MovieCast(long movieId)
        {
            var request = CreateRequest("movies/{movieId}/cast.json", new { movieId });

            return Execute<CastResponse>(request);
        }

        public MoviesResponse BoxOfficeMovies(int limit = 10, string country = "us")
        {
            var urlParams = new {limit, country};

            var request = CreateRequest("lists/movies/box_office.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse InTheatersMovies(int pageLimit = 16, int page = 1, string country = "us")
        {
            var urlParams = new { page_limit = pageLimit, page, country };

            var request = CreateRequest("lists/movies/in_theaters.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);            
        }

        public MoviesResponse OpeningMovies(int limit = 16, string country = "us")
        {
            var urlParams = new { limit, country };

            var request = CreateRequest("lists/movies/opening.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse UpcomingMovies(int pageLimit = 16, int page = 1, string country = "us")
        {
            var urlParams = new { page_limit = pageLimit, page, country };

            var request = CreateRequest("lists/movies/upcoming.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse TopRentals(int limit = 10, string country = "us")
        {
            var urlParams = new { limit, country };

            var request = CreateRequest("lists/dvds/top_rentals.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse CurrentReleaseDvds(int pageLimit = 16, int page = 1, string country = "us")
        {
            var urlParams = new { page_limit = pageLimit, page, country };

            var request = CreateRequest("lists/dvds/current_releases.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse NewReleaseDvds(int pageLimit = 16, int page = 1, string country = "us")
        {
            var urlParams = new { page_limit = pageLimit, page, country };

            var request = CreateRequest("lists/dvds/new_releases.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }

        public MoviesResponse UpcomingDvds(int pageLimit = 16, int page = 1, string country = "us")
        {
            var urlParams = new { page_limit = pageLimit, page, country };

            var request = CreateRequest("lists/dvds/upcoming.json", urlParams: urlParams);

            return Execute<MoviesResponse>(request);
        }
    }
}
