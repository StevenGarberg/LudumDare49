using LudumDare49.Unity.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Buttons
{
    [RequireComponent(typeof(Button))]
    public class AudibleButton : MonoBehaviour
    {
        [SerializeField]
        private string _audioClipName = "click";

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play(_audioClipName);
            });
        }
    }
}