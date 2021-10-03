using System;
using System.Text.Json.Serialization;

namespace LudumDare49.API.Models.Requests
{
    public class MatchResults
    {
        public long Id { get; set; }
        public string WinnerId{ get; set; }
        public string LoserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}