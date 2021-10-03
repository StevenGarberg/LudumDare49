using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Buttons
{
    [RequireComponent(typeof(Button))]
    public class LinkButton : MonoBehaviour
    {
        [SerializeField]
        private string _url;

        [Header("Components")] [SerializeField]
        private Button _button;

        private void Awake()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                Application.OpenURL(_url);
            });
        }
    }
}