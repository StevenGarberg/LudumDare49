using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Buttons
{
    [RequireComponent(typeof(Button))]
    public class WindowButton : MonoBehaviour
    {
        [SerializeField]
        private bool _closesWindow;
        
        [Header("Components")]
        [SerializeField]
        private Button _button;
        
        [SerializeField]
        private GameObject _window;

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _window.SetActive(!_closesWindow);
            });
        }
    }
}