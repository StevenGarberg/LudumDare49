using System;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : NetworkBehaviour
{
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
    private void Update()
    {
        if (!isLocalPlayer) return;
        
        CheckForMovement(KeyCode.Space, Vector3.up);
        CheckForMovement(KeyCode.W, Vector3.forward);
        CheckForMovement(KeyCode.D, Vector3.right);
        CheckForMovement(KeyCode.A, Vector3.left);
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
    public void CmdSpawnBall()
    {
        GameObject go = Instantiate(GameManager.Instance.BallPrefab);
        NetworkServer.Spawn(go);
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
    
    private void CheckForMovement(KeyCode keyCode, Vector3 direction)
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
            CmdSpawnBall();
        }
    }
    
    private Vector3 CalculateMovement(Vector3 direction)
    {
        return direction * (_speed * Time.deltaTime);
    }
}