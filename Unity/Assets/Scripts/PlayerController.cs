using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    [Header("Components")]
    [SerializeField]
    private SpriteRenderer _bodySpriteRenderer;
    
    [Header("SyncVars")]
    [SyncVar(hook = nameof(OnColorChanged))]
    public Color BodyColor = Color.white;
    
    #region Client Callbacks
    private void Update()
    {
        if (!isLocalPlayer) return;
        
        CheckForMovement(KeyCode.D, Vector3.right);
        CheckForMovement(KeyCode.A, Vector3.left);
    }
    #endregion

    #region Server Callbacks
    public override void OnStartLocalPlayer()
    {
        var color = ColorRandomizer.GetRandomPresetColor();
        CmdSetupPlayer(color);
    }
    #endregion

    #region Commands
    [Command]
    public void CmdSetupPlayer(Color color)
    {
        BodyColor = color;
    }
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
            transform.Translate(frameMovement);
        }
    }
    
    private Vector3 CalculateMovement(Vector3 direction)
    {
        return direction * (_speed * Time.deltaTime);
    }
}