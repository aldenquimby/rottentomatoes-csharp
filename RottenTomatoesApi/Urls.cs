namespace RottenTomatoesApi
{
    public class Urls
    {
        private readonly string _apiKey;

        public Urls(string apiKey)
        {
            _apiKey = apiKey;
        }

        public const string BASE_URL = @"http://api.rottentomatoes.com/api/public/v1.0";
	
        public string MoviesSearch(string query, int pageLimit = 30, int page = 1)
        {
            return BASE_URL + @"/movies.json?apikey=" + _apiKey + 
                   @"&q=" + query + 
                   @"&page_limit=" + pageLimit + 
                   @"&page=" + page;
        }
	
        public string MovieInfo(long movieId)
        {
            return BASE_URL + @"/movies/" + movieId + @".json?apikey=" + _apiKey;
        }
	
        public string MovieReviews(long movieId, ReviewType type = ReviewType.Top_Critic, int pageLimit = 20, int page = 1, string country = "us")
        {
            return BASE_URL + @"/movies/" + movieId + @"/reviews.json?apikey=" + _apiKey + 
                   @"&review_type=" + type.ToString().ToLower() + 
                   @"&page_limit=" + pageLimit + 
                   @"&page=" + page + 
                   @"&country=" + country;
        }
	
        public string MovieSimilar(long movieId, int limit = 5)
        {
            return BASE_URL + @"/movies/" + movieId + @"/similar.json?apikey=" + _apiKey + 
                   @"&limit=" + limit;
        }

        public string MovieClips(long movieId)
        {
            return BASE_URL + @"/movies/" + movieId + @"/clips.json?apikey=" + _apiKey;
        }
	
        public string MovieCast(long movieId)
        {
            return BASE_URL + @"/movies/" + movieId + @"/cast.json?apikey=" + _apiKey;
        }
    }
}