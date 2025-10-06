using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;

    [SerializeField] private float _paddleInfluence = 0.4f;

    private Rigidbody2D _rb;

    [SerializeField] private AudioSource _sfx;

    [SerializeField] private AudioClip _scoreSFX;
    [SerializeField] private AudioClip _paddleSFX;
    [SerializeField] private AudioClip _wallSFX;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        ResetBall();
    }

    void ResetBall()
    {
        _rb.linearVelocity = Vector2.zero;

        transform.position = Vector3.zero;

        Vector2 direction = new Vector2(
            Utilities.GetNonZeroRandomFloat(),
            Utilities.GetNonZeroRandomFloat()
        ).normalized;

        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.x, 0.0f))
            {
                Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            _sfx.resource = _paddleSFX;
        }
        else if (other.gameObject.CompareTag("Brick"))
        {
            _sfx.resource = _scoreSFX;
        }
        else
        {
            _sfx.resource = _wallSFX;
        }
        _sfx.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetBall();
    }

    void Update()
    {
        _rb.simulated = GameBehavior.Instance.State != Utilities.GameState.Pause;
    }
}