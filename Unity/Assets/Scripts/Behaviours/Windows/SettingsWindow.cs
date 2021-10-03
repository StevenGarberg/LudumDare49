using LudumDare49.Unity.Services;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Windows
{
    public class SettingsWindow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private InputField _displayNameInputField;

        [SerializeField]
        private InputField _favoriteColorInputField;

        private void OnEnable()
        {
            PlayerService.Fetch(player =>
            {
                _displayNameInputField.text = player.Data.DisplayName;
                _favoriteColorInputField.text = player.Data.FavoriteColor;
                TryAssignColor(player.Data.FavoriteColor);
            });

            _favoriteColorInputField.onValueChanged.AddListener(TryAssignColor);
        }

        private void TryAssignColor(string value)
        {
            _favoriteColorInputField.image.color = ColorUtility.TryParseHtmlString(value, out var color)
                ? color
                : Color.white;
        }
    }
}