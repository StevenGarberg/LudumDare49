using System.Collections;
using LudumDare49.Unity.Services;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Windows
{
    public class WaitingWindow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private GameObject _buttonsGroup;
        
        [SerializeField]
        private Text _connectingText;
        
        [SerializeField]
        private Button _closeButton;
        
        [SerializeField]
        private NetworkManager _networkManager;

        private Coroutine _animateConnectingTextRoutine;
        
        #region Unity Callbacks
        private void Start()
        {
            _closeButton.onClick.AddListener(() =>
            {
                _networkManager.StopClient();
            });
        }

        private void OnEnable()
        {
            _buttonsGroup.SetActive(false);
            _animateConnectingTextRoutine = StartCoroutine(AnimateConnectingTextRoutine());
            StartCoroutine(StartClientRoutine());

        }

        private void OnDisable()
        {
            _buttonsGroup.SetActive(true);
            StopCoroutine(_animateConnectingTextRoutine);
        }
        #endregion

        #region Coroutines
        private IEnumerator StartClientRoutine()
        {
            yield return new WaitForSeconds(3f);
            PlayerService.Fetch(player =>
            {
                _networkManager.StartClient();
            });
        }
        
        private IEnumerator AnimateConnectingTextRoutine()
        {
            yield return new WaitForSeconds(1);
            
            while (true)
            {
                for (var i = 0; i < 4; i++)
                {
                    var text = "Connecting";
                    for (var j = 1; j <= i; j++)
                    {
                        text += ".";
                    }
                    _connectingText.text = text;
                    
                    yield return new WaitForSeconds(1);
                }
            }
        }
        #endregion
    }
}