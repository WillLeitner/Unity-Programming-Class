using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _lowHealth = new Color(111, 35, 10, 255);
    [SerializeField] private Color _midHealth = new Color(204, 215, 34, 255);
    [SerializeField] private Color _fullHealth = new Color(11, 142, 16, 255);
    [SerializeField] private int Health;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetHealth();
    }

    void SetHealth()
    {
        if (Health == 3)
        {
            _spriteRenderer.color = _fullHealth;
        }
        else if (Health == 2)
        {
            _spriteRenderer.color = _midHealth;
        }
        else if (Health == 1)
        {
            _spriteRenderer.color = _lowHealth;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameBehavior.Instance.Score++;
            Health -= 1;
            SetHealth();
        }
    }

    void Update()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
        }

    }
}