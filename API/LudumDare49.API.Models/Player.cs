using System;
using System.ComponentModel.DataAnnotations;

namespace LudumDare49.API.Models
{
    public class Player : BaseResource
    {
        public string DisplayName { get; set; }
    }
}