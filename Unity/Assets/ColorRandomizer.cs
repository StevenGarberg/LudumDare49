using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var colors = new[]
        {
            Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow
        };
        var randomNumber = Random.Range(0, 8);
        _spriteRenderer.color = colors[randomNumber];
    }
}
