using LudumDare49.Unity.Clients;
using LudumDare49.Unity.Models;

namespace LudumDare49.Unity.Services
{
    public static class MatchService
    {
        public static void PostResults(MatchResults results)
        {
            MatchClient.PostResults(results);
        }
    }
}