# Rotten Tomatoes REST API for .NET

A simple C# wrapper for the HTTP-based Rotten Tomatoes API, which you can learn about at http://developer.rottentomatoes.com/docs/read/JSON

## Examples

#### Search for movies

    var rtClient = new RottenTomatoesRestClient("myApiKey");
    
    var wolverineMovies = rtClient.MoviesSearch("the wolverine");
    
#### Find similar movies

    var rtClient = new RottenTomatoesRestClient("myApiKey");
    
    const int wolverineMovieId = 771193517;
    
    var wolverineMovies = rtClient.MoviesSimilar(wolverineMovieId);

#### Browse new DVD releases

    var rtClient = new RottenTomatoesRestClient("myApiKey");
    
    var newDvds = rtClient.NewReleaseDvds();

#### And much more

This wrapper supports every end point of the <a href="http://developer.rottentomatoes.com/docs/read/JSON" target="_blank">Rotten Tomatoes JSON API</a>.

## Installation

You can add the Rotten Tomatoes API to your project using <a href="https://www.nuget.org/packages/RottenTomatoes.Api/" target="_blank">NuGet</a>. 
