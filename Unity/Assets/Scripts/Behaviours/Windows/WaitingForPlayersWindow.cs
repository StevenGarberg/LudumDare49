using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare49.Unity.Behaviours.Windows
{
    public class WaitingForPlayersWindow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Text _waitingText;
        
        [SerializeField]
        private Button _closeButton;
        
        [SerializeField]
        private NetworkManager _networkManager;

        private Coroutine _animateWaitingTextRoutine;
        
        #region Unity Callbacks

        private void Awake()
        {
            _networkManager = NetworkManager.singleton;
        }

        private void Start()
        {
            _closeButton.onClick.AddListener(() =>
            {
                _networkManager.StopClient();
            });
        }

        private void OnEnable()
        {
            _animateWaitingTextRoutine = StartCoroutine(AnimateWaitingTextRoutine());
        }

        private void OnDisable()
        {
            StopCoroutine(_animateWaitingTextRoutine);
        }
        #endregion

        #region Coroutines
        private IEnumerator AnimateWaitingTextRoutine()
        {
            yield return new WaitForSeconds(1);
            
            while (true)
            {
                for (var i = 0; i < 4; i++)
                {
                    var text = "Waiting";
                    for (var j = 1; j <= i; j++)
                    {
                        text += ".";
                    }
                    _waitingText.text = text;
                    
                    yield return new WaitForSeconds(1);
                }
            }
        }
        #endregion
    }
}