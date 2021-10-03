using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField]
        private Texture2D _cursor;

        private void Start()
        {
            UnityEngine.Cursor.SetCursor(_cursor, new Vector2(0, 0), CursorMode.ForceSoftware);
        }
    }
}