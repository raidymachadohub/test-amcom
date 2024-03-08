using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        int page = 1;
        var teamGols = new List<Data>();

        var resource = string.Format(
            "https://jsonmock.hackerrank.com/api/football_matches?year={0}&team1={1}&page={2}", year,
            team, page);

        var teamAnalytic = GetScored(resource);

        if (teamAnalytic.total_pages > 0)
        {
            for (int i = page; i <= teamAnalytic.total_pages; i++)
            {
                resource = string.Format(
                    "https://jsonmock.hackerrank.com/api/football_matches?year={0}&team1={1}&page={2}", year,
                    team, i);
                
                teamGols.AddRange(GetScored(resource).data);
            }
        }

        return CalulateGoals(teamGols);
    }

    private static int CalulateGoals(List<Data> teamGoals)
        => teamGoals.Sum(goal => goal.team1goals) + teamGoals.Sum(goal => goal.team2goals);

    private static TeamAnalytic GetScored(string resource)
    {
        using var httpClient = new HttpClient();
        var getScoreTask = Task.Run(() => httpClient.GetAsync(resource));
        getScoreTask.Wait();
        var getScoreResponse = getScoreTask.Result;

        if (!getScoreResponse.IsSuccessStatusCode)
            return new TeamAnalytic();

        var getScoreResult = Task.Run(() => getScoreResponse.Content.ReadAsStringAsync());
        getScoreResult.Wait();
        var getScore = getScoreResult.Result;

        var teamAnalytic = JsonConvert.DeserializeObject<TeamAnalytic>(getScore);

        return teamAnalytic;
    }
}