using LudumDare49.Unity.Managers;
using LudumDare49.Unity.Services;
using LudumDare49.Unity.Utilities;
using Mirror;
using UnityEngine;

namespace LudumDare49.Unity.Behaviours
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private Camera _camera;
        
        [SerializeField]
        private float _speed = 10.0f;

        [Header("Components")]
        [SerializeField]
        private SpriteRenderer _bodySpriteRenderer;

        [SerializeField]
        private Rigidbody2D _rigidbody;
    
        [Header("SyncVars")]
        [SyncVar(hook = nameof(OnColorChanged))]
        public Color BodyColor = Color.white;
    
        #region Client Callbacks

        private void Start()
        {
            if (isClient)
                _camera = Camera.main;
        }

        private void Update()
        {
            if (!isLocalPlayer) return;
            
            CheckForMovement(KeyCode.D, Vector2.right);
            CheckForMovement(KeyCode.A, Vector2.left);
            CheckForShoot();
        }
        #endregion

        #region Server Callbacks
        public override void OnStartLocalPlayer()
        {
            var color = ColorUtility.TryParseHtmlString(PlayerService.Player.Data.FavoriteColor, out var parsedColor)
                ? parsedColor
                : ColorRandomizer.GetRandomPresetColor();

            CmdSetupPlayer(color);
        }
        #endregion

        #region Commands
        [Command]
        public void CmdSetupPlayer(Color color)
        {
            BodyColor = color;
        }

        [Command]
        public void CmdSpawnBall(Vector2 shootDirection)
        {
            Vector2 position = transform.position;
            GameObject go = Instantiate(GameManager.Instance.BallPrefab, position + (shootDirection.normalized), Quaternion.identity);
            NetworkServer.Spawn(go);
            go.GetComponent<Rigidbody2D>().AddForce(CalculateMovement(shootDirection * 10), ForceMode2D.Impulse);
        }
        #endregion
    
        #region Client RPC
        #endregion
    
        #region SyncVar Callbacks
        private void OnColorChanged(Color _Old, Color _New)
        {
            _bodySpriteRenderer.color = _New;
        }
        #endregion
    
        private void CheckForMovement(KeyCode keyCode, Vector2 direction)
        {
            if (Input.GetKey(keyCode))
            {
                var frameMovement = CalculateMovement(direction);
                _rigidbody.AddForce(frameMovement, ForceMode2D.Impulse);
            }
        }

        private void CheckForShoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var shootDirection = Input.mousePosition;
                shootDirection = _camera.ScreenToWorldPoint(shootDirection);
                shootDirection -= transform.position;
                CmdSpawnBall(shootDirection);
            }
        }
    
        private Vector3 CalculateMovement(Vector2 direction)
        {
            return direction * (_speed * Time.deltaTime);
        }
    }
}