using ConsoleTables;
using Flagging;
using Flagging.Data;
using System.Drawing.Printing;
using System.Linq;

var dbContext = new DataContext();

// #
// the database contains: 
// 1. users
// 2. articles
// 3. comments
// 4. flags -> A flag is an instance where someone reported a user/article/comment as offensive for review
//
// ##
// [ ] the goal of this excercise is to create a query that would pull flags from the database.
// [ ] each row in the table that will be written in the Console represents all flags that were ever created for a single user/article/comment
// 
// ###
// [ ] have most recent flags at the top
// [ ] filter by keyword (match on user name, article description and comment message)
// [ ] BONUS: implement paging
//
// ####
// Example: 
//var flaggedItems = new List<FlaggedItemRow>
//{
//    new FlaggedItemRow { ItemId = 1, ItemType = "Member", ItemDescription = "Marko Kosovic", FlagCounts = 4, DateLastFlagged = new DateTime(2023, 1, 1) },
//    new FlaggedItemRow { ItemId = 1, ItemType = "Article", ItemDescription = "Getting Started with EF", FlagCounts = 2, DateLastFlagged = new DateTime(2023, 6, 1) },
//    new FlaggedItemRow { ItemId = 1, ItemType = "Comment", ItemDescription = "WOW", FlagCounts = 1, DateLastFlagged = new DateTime(2023, 11, 7) }
//}.OrderByDescending(x => x.DateLastFlagged);

var flaggedItems = new List<FlaggedItemRow>();

// write code here
int pageSize = 25; 
int pageNumber = 1; 

flaggedItems = dbContext.Flags
    .GroupBy(fi => new { fi.Type, fi.ItemId, fi.DateCreated })
    .Select(group => new FlaggedItemRow
    {
        ItemId = group.Key.ItemId.Value,
        ItemType = group.Key.Type.ToString(),
        FlagCounts = dbContext.Flags.Where(x => x.ItemId == group.Key.ItemId.Value && x.Type == group.Key.Type).Count(),
        ItemDescription = group.Key.Type == FlaggedContentType.Article ? group.First().Article.Description.Substring(0, 10) :
                  group.Key.Type == FlaggedContentType.Comment ? group.First().Comment.Message.Substring(0, 10) :
                  group.Key.Type == FlaggedContentType.Member ? $"{group.First().ReportedUser.FirstName} {group.First().ReportedUser.LastName}".Substring(0, 10) : "N/A",
        DateLastFlagged = group.Key.DateCreated // Please remove the .Substring(0, 10)... Only added to have a broad view of the result set. Thanks
    })
    .OrderByDescending(x => x.DateLastFlagged)
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToList();

WriteTable(flaggedItems);

Console.ReadKey();

void WriteTable(IEnumerable<FlaggedItemRow> flaggedItems)
{
    ConsoleTable
        .From<FlaggedItemRow>(flaggedItems)
        .Configure(o => o.NumberAlignment = Alignment.Right)
        .Write(Format.Alternative);
}