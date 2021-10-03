using Mirror;
using UnityEngine;

namespace Managers
{
    public class GameManager : NetworkBehaviour
    {
        public static GameManager Instance;
    
        public bool Turn;

        [Header("Prefabs")]
        public GameObject BallPrefab;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }
    
        private void OnServerInitialized()
        {
            if (!isServer) return;
        }
    }
}
