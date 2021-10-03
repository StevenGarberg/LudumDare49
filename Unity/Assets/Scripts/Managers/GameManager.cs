using System;
using System.Collections;
using System.Linq;
using Mirror;
using UnityEngine;

namespace LudumDare49.Unity.Managers
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

        private void Start()
        {
            if (isServer)
            {
                StartCoroutine(GameLoopRoutine());
            }
        }

        private void OnServerInitialized()
        {
            if (!isServer) return;
        }

        private IEnumerator GameLoopRoutine()
        {
            while (true)
            {
                while (GetCurrentPlayerCount() < 2)
                {
                    yield return new WaitForSeconds(1);
                }
            
                Debug.Log("Game is beginning");
                while (GetCurrentPlayerCount() == 2)
                {
                    // TODO: Game is in session
                    yield return new WaitForSeconds(1);
                }
                
                // TODO: Break down game
            }
        }

        private int GetCurrentPlayerCount()
        {
            return NetworkServer.connections.Count(x => x.Value != null);
        }
    }
}
