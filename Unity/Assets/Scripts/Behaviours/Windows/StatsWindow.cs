using System.Globalization;
using LudumDare49.Unity.Services;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Windows
{
    public class StatsWindow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Text _gamesWonText;

        [SerializeField]
        private Text _gamesLostText, _totalGamesText, _firstPlayedAtText;

        private void OnEnable()
        {
            PlayerService.Fetch(player =>
            {
                _gamesWonText.text = player.Data.Wins.ToString();
                _gamesLostText.text = player.Data.Losses.ToString();
                _totalGamesText.text = (player.Data.Wins + player.Data.Losses).ToString();
                _firstPlayedAtText.text = player.CreatedAt.ToLocalTime().ToString(CultureInfo.CurrentCulture);
            });
        }
    }
}