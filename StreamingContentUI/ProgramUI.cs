using StreamingContentData.Content;
using StreamingContentData.Enums;
using StreamingContentEntityData;
using StreamingContentRepository;


namespace StreamingContentUI;

public class ProgramUI
{
    private readonly StreamingContentRepository.StreamingContentRepository _repo = new StreamingContentRepository.StreamingContentRepository();
    public ProgramUI() { }

    public void Run()
    {
        SeedContentList();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            System.Console.WriteLine("enter the  nummber of the option you would like to select:\n " +
            "1. Show all streaming content\n" +
            "2. Find streaming contnent by title\n" +   //  '\n +' new line in console
            "3. Add new streaming content\n" +
            "4. Remove streaming content\n" +
            "5. Update existing content\n" +
            "6. Exit\n" +
            "=============================================================\n");

            string userInput = Console.ReadLine()!;

            switch (userInput)
            {
                case "1":
                    ShowAllContent();
                    break;
                case "2":
                    ShowContentByTitle();
                    break;
                 case "3":
                    CreateNewContent();
                    break;
                case "4":
                    RemoveContent();
                    break;
                case "5":
                    UpdateExistingContent();
                    break;
                case "6":
                    isRunning = CloseApplication();
                    break;
                 default:
                    System.Console.WriteLine("invalid selection. try again");
                    break;
            }
        }
    }
    private bool CloseApplication()
    {
        System.Console.WriteLine("thanks for using this app!");
        PressAnyKey();
        return false;
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("press any key to continue...");
        Console.ReadKey();
    }

    private void ShowAllContent()
    {
        Console.Clear();

        List<StreamingContentEntity> listOfContent = _repo.GetAllStreamingContent();

        if(listOfContent.Count > 0)
        {
            foreach(StreamingContentEntity content in listOfContent)
            {
                ShowStreamingContentDetails(content);
            }
        }
        else
        {
            System.Console.WriteLine("Sorry, no content available :( ");
        }
        PressAnyKey();
    }

    private void ShowStreamingContentDetails(StreamingContentEntity content)
    {
        System.Console.WriteLine($"Title: {content.Title}\n" +
                                $"Description: {content.Description}\n"+
                                $"Star Rating: {content.StarRating}\n" +
                                $"Maturity Rating: {content.MaturityRating}\n" +
                                $"Genre Type: {content.GenreType}\n" +
                                $"Location: {content.Location}\n" +
                                $"Family Friendly: {content.IsFamilyFriendly}");
    }

    private void ShowContentByTitle()
    {
        System.Console.WriteLine("enter a title:");
        string userInput = Console.ReadLine()!;
        StreamingContentEntity content = _repo.GetStreamingContentByTitle(userInput);
        if(content != null)
        {
            ShowStreamingContentDetails(content);
        }
        else
        {
            System.Console.WriteLine("Invalid title. Could not find results");
        }
        PressAnyKey();
    }

    private StreamingContentEntity AddStreamingContentDetails()
    {
        StreamingContentEntity content = new StreamingContentEntity();

        // title
        System.Console.WriteLine("please input a title:");
        string userInputTitle = Console.ReadLine()!;    //*  '!' makes readline nullable (clears warning)
        content.Title = userInputTitle;

        // description
        System.Console.WriteLine("please input a description:");
        string userInputDescription = Console.ReadLine()!;
        content.Description = userInputDescription;

        // star rating
        System.Console.WriteLine("please input a star rating:");
        string userInputStarRating = Console.ReadLine()!;
        content.StarRating = Convert.ToDouble(userInputStarRating);

        // location
        System.Console.WriteLine("please input a location:");
        string userInputLocation = Console.ReadLine()!;
        content.Location = userInputLocation;

        // mat rating
        System.Console.WriteLine("please input a maturity rating:\n"+
                                "1. G\n"+
                                "2. PG\n" +
                                "3. PG_13\n" +
                                "4. R\n" +
                                "5. TV_Y\n" +
                                "6. TV_G\n" +
                                "7. TV_PG\n" +
                                "8. TV_14\n" +
                                "9. TV_MA\n" +
                                "10. M\n");
        string userInputMaturity = Console.ReadLine()!.ToUpper();
        switch(userInputMaturity)
        {
            case "1":
            case "G":
                content.MaturityRating = MaturityRating.G;
                break;
            case "2":
            case "PG":
                content.MaturityRating = MaturityRating.PG;
                break;
            case "3":
            case "PG_13":
                content.MaturityRating = MaturityRating.PG_13;
                break;
            case "4":
            case "R":
                content.MaturityRating = MaturityRating.R;
                break;
            case "5":
            case "TV_Y":
                content.MaturityRating = MaturityRating.TV_Y;
                break;
            case "6":
            case "TV_G":
                content.MaturityRating = MaturityRating.TV_G;
                break;
            case "7":
            case "TV_PG":
                content.MaturityRating = MaturityRating.TV_PG;
                break;
            case "8":
            case "TV_14":
                content.MaturityRating = MaturityRating.TV_14;
                break;
            case "9":
            case "TV_MA":
                content.MaturityRating = MaturityRating.TV_MA;
                break;
            case "10":
            case "M":
                content.MaturityRating = MaturityRating.M;
                break;
            default:
                System.Console.WriteLine("invalid maturity rating");
                break;
        }

        // genre
        System.Console.WriteLine("please enter a genre by entering the corresponding number:\n" +
                                "1. Horror\n" +
                                "2. RomCom\n" +
                                "3. Drama\n" +
                                "4. Documentary\n" +
                                "5. Scifi\n" +
                                "6. Reality\n");

        string userInputGenre = Console.ReadLine()!;

        int genreId = int.Parse(userInputGenre);

        content.GenreType = (GenreType)genreId;

        Console.WriteLine("What kind of content is this?\n" +
                          "1. Movie\n" +
                          "2. Show\n");

        var userInputType = Console.ReadLine()!;

        switch (userInputType)
        {
            case "1":
                Console.WriteLine("You chose the Movie Type.");

                return new Movie
                {
                    Title = content.Title,
                    Description = content.Description,
                    StarRating = content.StarRating,
                    MaturityRating = content.MaturityRating,
                    GenreType = content.GenreType
                };

            case "2":
                Console.WriteLine("You chose the Show Type.");

                var theShow = new Show
                {
                    Title = content.Title,
                    Description = content.Description,
                    StarRating = content.StarRating,
                    MaturityRating = content.MaturityRating,
                    GenreType = content.GenreType
                };

                System.Console.WriteLine("Are there any Episodes?");
                var episode = new Episode();
                Console.WriteLine("Episode Title:");
                var userInputEpisodeTitle = Console.ReadLine()!;
                episode.Title = userInputEpisodeTitle;

                theShow.Episodes.Add(episode);

                return theShow;

            default:
                return content;
        }

    }

    private void CreateNewContent()
    {
        // create a streaming content entity object
        StreamingContentEntity content = AddStreamingContentDetails();
        // then add to list
        if(_repo.AddContent(content))
        {
            System.Console.WriteLine("Your content was added");
        }
        else
        {
            System.Console.WriteLine("Your content was not added");
        }
        PressAnyKey();
    }

    private void RemoveContent()
    {
        System.Console.WriteLine("Which item would you like to remove?");

        List<StreamingContentEntity> contentList = _repo.GetAllStreamingContent();

        int count = 0;
        foreach(StreamingContentEntity content in contentList)
        {
            // count = count + 1;   same thing as below, another way to write it
            count++;
            System.Console.WriteLine($"{count}. {content.Title}");
        }

        int targetContentId = int.Parse(Console.ReadLine()!);
        int targetIndex = targetContentId - 1;

        if (targetIndex >= 0 && targetIndex < contentList.Count)
        {
            // contentList[number of index value]
            StreamingContentEntity desiredContent = contentList[targetIndex];

            if(_repo.DeleteExistingContent(desiredContent))
            {
                System.Console.WriteLine($"{desiredContent.Title} was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine($"{desiredContent.Title} failed to be deleted.");
   
            }
        }
        else
        {
            System.Console.WriteLine("invalid selection");
        }
        PressAnyKey();
    }

    private void UpdateExistingContent()
    {
        System.Console.WriteLine("Enter a title:");

        string userInput = Console.ReadLine()!;

        StreamingContentEntity content = _repo.GetStreamingContentByTitle(userInput);

        if (content != null)
        {
            StreamingContentEntity updatedData = AddStreamingContentDetails();
            if(_repo.UpdateExistingContent(userInput, updatedData))
            {
                System.Console.WriteLine("content was successfully updated!");
            }
            else
            {
                System.Console.WriteLine("failed to update");
            }
        }
        else
        {
            System.Console.WriteLine("invalid title. could not find results.");
        }

        PressAnyKey();
    }

    private void SeedContentList()
    {
        StreamingContentEntity toyStory = new StreamingContentEntity("Toy Story", "a movie about toys", 4, "disney+",
        MaturityRating.G, GenreType.Scifi);
        StreamingContentEntity squidGames = new StreamingContentEntity("Squid Games", "a show about playing deadly games", 4,
         "Netflix", MaturityRating.TV_MA, GenreType.Horror);

        _repo.AddContent(toyStory);
        _repo.AddContent(squidGames);
    }
}
