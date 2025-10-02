using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    [SerializeField] private TMP_Text _scoreUI;
    private int _score = 0;

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
    void Start()
    {
        Score = 0;
    }
}