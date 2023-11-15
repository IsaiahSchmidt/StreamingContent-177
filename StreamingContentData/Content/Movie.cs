namespace StreamingContentData.Content;

using StreamingContentData.Enums;
using StreamingContentEntityData;
public class Movie : StreamingContentEntity
{
    public Movie() {}
      public Movie(string title, string description, double starRating, 
        string location, MaturityRating maturityRating, GenreType genreType) : base(title, description, 
        starRating, location, maturityRating, genreType)
    {
        
    }
    public double RunTime { get; set; }
    
}
