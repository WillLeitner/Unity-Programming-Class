using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    [SerializeField] private TMP_Text _scoreUI;
    private int _score = 0;
    public Utilities.GameState State;
    [SerializeField] private KeyCode _pauseButton;
    [SerializeField] private TMP_Text _messagesUI;

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(_pauseButton))
        {
            State = State == Utilities.GameState.Play ? Utilities.GameState.Pause : Utilities.GameState.Play;

            _messagesUI.enabled = !_messagesUI.enabled;
        }
    }
    void Start()
    {
        Score = 0;
        _messagesUI.enabled = false;
    }
}