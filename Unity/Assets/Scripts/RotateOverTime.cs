using UnityEngine;

namespace DefaultNamespace
{
    public class RotateOverTime : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1.0f;

        [SerializeField]
        private Vector3 _direction = Vector3.right;
        
        private void Update()
        {
            transform.Rotate(_direction * _speed * Time.deltaTime);
        }
    }
}