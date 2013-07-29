using NUnit.Framework;

namespace RottenTomatoes.Api.Tests
{
    /// <summary>
    /// Trivial tests to ensure no errors with valid API key.
    /// </summary>
    [TestFixture]
    public class RestClientTests
    {
        private IRottenTomatoesRestClient _client;

        // the wolverine
        private const int MOVIE_ID = 771193517;
        private const string IMDB_MOVIE_ID = "1430132";
        private const string SEARCH_Q = "the wolverine";

        [SetUp]
        public void Setup()
        {
            const string apiKey = ""; // PUT API KEY HERE, THEN RUN TESTS

            _client = new RottenTomatoesRestClient(apiKey);
        }

        [Test]
        public void MoviesSearch()
        {
            var resp = _client.MoviesSearch(SEARCH_Q);

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void MoviesInfo()
        {
            var resp = _client.MovieInfo(MOVIE_ID);

            Assert.IsNotNull(resp);
        }

        [Test]
        public void MovieAlias()
        {
            var resp = _client.MovieAlias(IMDB_MOVIE_ID);

            Assert.IsNotNull(resp);
        }

        [Test]
        public void MovieReviews()
        {
            var resp = _client.MovieReviews(MOVIE_ID);

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void MovieSimilar()
        {
            var resp = _client.MovieSimilar(MOVIE_ID);

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void MovieClips()
        {
            var resp = _client.MovieClips(MOVIE_ID);

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void MovieCast()
        {
            var resp = _client.MovieCast(MOVIE_ID);

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void BoxOfficeMovies()
        {
            var resp = _client.BoxOfficeMovies();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void InTheatersMovies()
        {
            var resp = _client.InTheatersMovies();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void OpeningMovies()
        {
            var resp = _client.OpeningMovies();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void UpcomingMovies()
        {
            var resp = _client.UpcomingMovies();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void TopRentals()
        {
            var resp = _client.TopRentals();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void CurrentReleaseDvds()
        {
            var resp = _client.CurrentReleaseDvds();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void NewReleaseDvds()
        {
            var resp = _client.NewReleaseDvds();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }

        [Test]
        public void UpcomingDvds()
        {
            var resp = _client.UpcomingDvds();

            Assert.IsNotNull(resp);
            Assert.IsNull(resp.Error);
        }
    }
}
