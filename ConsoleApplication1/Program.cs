using System;
using Newtonsoft.Json;
using RottenTomatoesApi;

namespace ConsoleApplication1
{
    public class Program
    {
        const string MY_API_KEY = @"";

        public static void Main(string[] args)
        {
            IRottenTomatoesRestClient client = new RottenTomatoesRestClient(MY_API_KEY);

            const int movieId = 7;

            object resp = client.MovieInfo(movieId);
            resp.Dump();

            resp = client.MovieAlias("12345");
            resp.Dump();
            
            resp = client.MovieReviews(movieId);
            resp.Dump();
            
            resp = client.MovieSimilar(movieId);
            resp.Dump();
            
            resp = client.MovieClips(movieId);
            resp.Dump();
            
            resp = client.MovieCast(movieId);
            resp.Dump();
            
            resp = client.BoxOfficeMovies();
            resp.Dump();
            
            resp = client.InTheatersMovies();
            resp.Dump();
            
            resp = client.OpeningMovies();
            resp.Dump();
            
            resp = client.UpcomingMovies();
            resp.Dump();
            
            resp = client.TopRentals();
            resp.Dump();
            
            resp = client.CurrentReleaseDvds();
            resp.Dump();
            
            resp = client.NewReleaseDvds();
            resp.Dump();
            
            resp = client.UpcomingDvds();
            resp.Dump();
        }
    }

    public static class Extensions
    {
        public static void Dump(this object o)
        {
            var ser = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(ser);
        }
    }
}
