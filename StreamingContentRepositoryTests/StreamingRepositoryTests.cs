namespace StreamingContentRepositoryTests;

using StreamingContentData.Content;
using StreamingContentData.Enums;
using StreamingContentRepository;

public class StreamingContentRepositoryTests
{
    private StreamingRepository _repo;
    private Movie _movieA;
    private Movie _movieB;
    private Show _showA;
    private List<Episode> _episodes;
    private Episode _episodeA;
    private Episode _episodeB;
    private Show _showB;

    public StreamingContentRepositoryTests()
    {
        _repo = new StreamingRepository();
        _movieA = new Movie("Bad Boys", "cop film", 4, "netflix", MaturityRating.R, GenreType.Action);
        _movieB = new Movie("50 first dates", "girl forgets stuff", 2, "hulu", MaturityRating.R, GenreType.RomCom);
        _showA = new Show("The price is right", "guess prices", 5, "ABC", MaturityRating.TV_G, GenreType.Reality);
        _episodes = new List<Episode>
        {
            new Episode
            {
                Title = "The price is right episode 1",
                RunTime = .5d,
                SeasonNumber = 1
            },
            new Episode
            {
                Title = "The price is right episode 2",
                RunTime = .5d,
                SeasonNumber = 1
            },
        };
        _showA.Episodes = _episodes;

        _repo.AddContent(_movieA);
        _repo.AddContent(_movieB);
        _repo.AddContent(_showA);
    }
    [Fact]
    public void TotalCount()
    {
        // ACT -> write code that is going to perform
        int actual = _showA.EpisodeCount;
        int expected = 2;

        // ASSERT -> test
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AverageShowTime()
    {
        double expected = .5d;
        double actual = _showA.AverageRunTime;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetShowTitle()
    {
        Show retrievedShow = _repo.GetShowByTitle("The price is RIGHT");

        Show expected = _showA;
        Show actual = retrievedShow;

        Assert.Equal(expected, actual);
    }
}