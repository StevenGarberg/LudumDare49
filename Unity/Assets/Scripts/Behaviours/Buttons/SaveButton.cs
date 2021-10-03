using LudumDare49.Unity.Models;
using LudumDare49.Unity.Services;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Buttons
{
    [RequireComponent(typeof(Button))]
    public class SaveButton : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Button _button;

        [SerializeField]
        private InputField _displayNameInput;
        
        [SerializeField]
        private InputField _favoriteColorInput;

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                var settings = new PlayerSettings
                {
                    DisplayName = _displayNameInput.text?.Trim(),
                    FavoriteColor = _favoriteColorInput.text?.Trim()
                };
                PlayerService.UpdateSettings(settings);
            });
        }
    }
}