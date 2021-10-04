using LudumDare49.Unity.Managers;
using Mirror;
using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    public class Ball : NetworkBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isClient) return;
            
            if (other.gameObject.CompareTag("Box"))
                AudioManager.Instance.Play("box-hit");
            else
                AudioManager.Instance.Play("other-hit");
        }
    }
}