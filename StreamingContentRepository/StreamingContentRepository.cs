namespace StreamingContentRepository;
using StreamingContentEntityData;

public class StreamingContentRepository
{
    // fake database
    protected readonly List<StreamingContentEntity> _contentDb = new List<StreamingContentEntity>();

    //* CRUD 

    // Create method
    public bool AddContent(StreamingContentEntity content)
    {
        int startingCount = _contentDb.Count;
        _contentDb.Add(content);

        if (_contentDb.Count > startingCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Read method
    public List<StreamingContentEntity> GetAllStreamingContent()
    {
        return _contentDb;
    }
    // Read by title method
    public StreamingContentEntity GetStreamingContentByTitle(string title)
    {
        foreach (StreamingContentEntity content in _contentDb)
        {
            if (content.Title == title)
            {
                return content;
            }
        }
        return null;

        //  _contentDb.SingleOrDefault(c => c.Title == title);      //* linq version
    }
    // Update method
    public bool UpdateExistingContent(string originalTitle, StreamingContentEntity updatedData)
    {
        // retrieve streaming content objects from our collection by title
        StreamingContentEntity entityInDb = GetStreamingContentByTitle(originalTitle);
        if(entityInDb != null)
        {
            // update the object with the properties that I am wanting to update
            entityInDb.Title = updatedData.Title;
            entityInDb.Location = updatedData.Location;
            entityInDb.StarRating = updatedData.StarRating;
            entityInDb.MaturityRating = updatedData.MaturityRating;
            entityInDb.Description = updatedData.Description;
            entityInDb.GenreType = updatedData.GenreType;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Delete method
    public bool DeleteExistingContent(StreamingContentEntity content)
    {
        bool deleteResult = _contentDb.Remove(content);
        return deleteResult;
    }
}
