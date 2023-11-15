﻿namespace StreamingContentEntityData;

using StreamingContentData.Enums;

// application -> user can keep up to date list of streaming content
// there are several different kinds of streaming content - movies, tv, etc
// collection of streaming content objects
// repository pattern architecture - data and business logic separate

//* inheritance with Streaming Content objects
public class StreamingContentEntity
{
    public StreamingContentEntity() {}

    public StreamingContentEntity(string title, string description, double starRating, 
        string location, MaturityRating maturityRating, GenreType genreType)
    {
        Title = title;
        Description = description;
        StarRating = starRating;
        Location = location;
        MaturityRating = maturityRating;
        GenreType = genreType;
    }

    public string Title { get; set; }   
    public string Description { get; set; }   
    public double StarRating { get; set; }   
    public string Location { get; set; }   
    public MaturityRating MaturityRating { get; set; }
    public GenreType GenreType { get; set; }
    public bool IsFamilyFriendly
    {
        get
        {
            switch (MaturityRating)
            {
                case MaturityRating.G:
                case MaturityRating.PG:
                case MaturityRating.TV_Y:
                case MaturityRating.TV_G:
                case MaturityRating.TV_PG:
                    return true;
                default: 
                    return false;
            }
        }
    }
}
