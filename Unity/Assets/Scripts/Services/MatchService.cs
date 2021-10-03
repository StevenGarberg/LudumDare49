using Clients;
using Models;

namespace Services
{
    public static class MatchService
    {
        public static void PostResults(MatchResults results)
        {
            MatchClient.PostResults(results);
        }
    }
}