namespace StreamingContentEntityData;

// application -> user can keep up to ddate list of streaming content
// there are several different kinds of streaming content - movies, tv, etc
// collection of streaming content objects
// repository pattern architecture - data and business logic separate

// inheritance with Streaming Content objects
public abstract class StreamingContentEntity
{
    public StreamingContentEntity() {}

    public string Title { get; set; }   
    public string Description { get; set; }   
    public double StarRating { get; set; }   
    public double Duration { get; set; }   
    public string Location { get; set; }   
}
