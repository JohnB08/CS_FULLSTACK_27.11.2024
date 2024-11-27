using System.Globalization;
using System.Text.Json;
using CS_FULLSTACK_27._11._2024;

internal class Program
{
    public static void Main()
    {
        //Laster inn datasettet vårt i minne til aplikasjonen vår.
        var movies = LoadMovies();
        //velger en random film fra datasettet vårt. 
        var randomMovie = GetRandomMovie(movies);
        //Filtrerer basert på sjanger
        var moviesByGenre = GetMoviesByGenre(movies, "Silent");
        //Filtrer basert på et navn
        var moviesByActorName = GetMovieByActor(movies, "Hugh Grant");
        //Filtrerer basert på to årstall.
        var moviesByReleaseYear = GetMoviesByYear(movies, 1900, 1920);
        SaveResults(moviesByGenre);
        //Vi ser hvor mange filmer vi har. 
        Console.WriteLine(movies.Count);

    }
    //En metode for å laste inn movies.Json til memory;
    static List<MovieModel> LoadMovies()
    {
        try
        {
            var jsonString = File.ReadAllText("movies.json");
            var movies = JsonSerializer.Deserialize<List<MovieModel>>(jsonString);
            return movies;
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong when trying to fetch our datamodel");
            throw;
        }
    }
    //En metode for å lagre vårt resultat til en result.json fil;
    static void SaveResults(object result)
    {
        try
        {
            var jsonString = JsonSerializer.Serialize(result);
            File.WriteAllText($"{Guid.NewGuid()}-result.json", jsonString);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something went wrong writing result to file. {ex.Message}");
        }
    }
    //En metode for å velge en tilfeldig film fra datasettet vårt;
    static MovieModel GetRandomMovie(List<MovieModel> movies)
    {
        return movies.OrderBy(_ => Guid.NewGuid()).FirstOrDefault()!;
    }

    //En metode som skal kunne filtrere basert på sjanger.
    static List<MovieModel> GetMoviesByGenre(List<MovieModel> movies, string genre)
    {
        return movies.Where(movie => movie.Genres.Contains(genre)).ToList();
    }

    //En metode som skal kunne søke etter skuespiller;

    static List<MovieModel> GetMovieByActor(List<MovieModel> movies, string actorName)
    {
        return movies.Where(movie => movie.Cast.Any(name => name.Contains(actorName))).ToList();
    }

    //En metode som skal kunne filtrere basert på utgivelses år.
    static List<MovieModel> GetMoviesByYear(List<MovieModel> movies, int lowerYear, int higherYear)
    {
        return movies.Where(movie => movie.Year > lowerYear && movie.Year < higherYear).ToList();
    }


}
