using System.Reflection;
using StreamingContentData.Content;
using StreamingContentEntityData;

namespace StreamingContentRepository;

public class StreamingRepository : StreamingContentRepository
{
    public Show GetShowByTitle(string title)
    {
        foreach (StreamingContentEntity content in _contentDb)
        {
            if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Show)) // long version
            {
                return (Show)content;
            }
        }
        return null;
    }

    public List<Show> GetAllShows()
    {
        List<Show> allShows = new List<Show>();

        foreach (var content in _contentDb)
        {
            if (content is Show)    // short verion
            {
                allShows.Add((Show)content);
            }
        }
        return allShows;    // return outside foreach loop so the loop will iterate thru everything before leaving method

        // return _contentDb.Where(e => e is Show).Select(e => (Show)e).ToList()    //* linq version
    }

        public Movie GetMovieByTitle(string title)
    {
        foreach (StreamingContentEntity content in _contentDb)
        {
            if (content.Title.ToLower() == title.ToLower() && content.GetType() == typeof(Movie)) // long version
            {
                return (Movie)content;
            }
        }
        return null;

        // return (Movie)_contentDb.FirstOrDefault(e => e.Title.ToLower() == title.ToLower() && e is Movie);    //* linq version
    }

    public List<Movie> GetAllMovies()
    {
        List<Movie> allMovies = new List<Movie>();

        foreach (var content in _contentDb)
        {
            if (content is Movie)    // short verion
            {
                allMovies.Add((Movie)content);
            }
        }
        return allMovies;    // return outside foreach loop so the loop will iterate thru everything before leaving method
    }
}
