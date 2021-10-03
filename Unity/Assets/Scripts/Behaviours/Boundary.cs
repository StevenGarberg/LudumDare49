using Mirror;
using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    public class Boundary : NetworkBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isServer) return;

            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                // TODO: Blood fx
                // TODO: Announce who won on clients
            }
        }
    }
}