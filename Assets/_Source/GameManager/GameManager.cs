using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singltone;

    [Header("Prefabs")]
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _obstaclePrefab;
    [Header("Spawn Points")]
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private Transform _obstacleSpawn;
    [Header("Game Settings")]
    [SerializeField][Tooltip("How fast obstacles moving")][Range(1,4)] private float _gameSpeed;
    [SerializeField] private float _timeToRestart;

    private Player _player;
    private LevelPreparing _levelPreparing;
    private GameScore _gameScore;
    private GameEventHandler _gameEventHandler;
    private GameOver _gameOver;
    private static bool _isFirstRun = true;

    public GameObject PlayerPrefab { get => _playerPrefab; }
    public GameObject ObstaclePrefab { get => _obstaclePrefab; }
    public Transform PlayerSpawn { get => _playerSpawn; }
    public Transform ObstacleSpawn { get => _obstacleSpawn; }
    public Player Player { get => _player; set => _player = value; }
    public GameScore GameScore { get => _gameScore; set => _gameScore = value; }
    public GameEventHandler GameEvents { get => _gameEventHandler; }
    //init commit

    public float GameSpeed { get => _gameSpeed; }

    private void Awake()
    {
        CheckSingltone();
        if (_levelPreparing == null) _levelPreparing = new LevelPreparing();
        if (_gameEventHandler == null) _gameEventHandler = new GameEventHandler();
        if (_gameScore == null) _gameScore = new GameScore();
        if (_gameOver == null) _gameOver = new GameOver(_timeToRestart);
        _levelPreparing.FillScene();
        LoadGame();
    }
    private void LoadGame()
    {
        if (_isFirstRun)
        {
            Player.Singltone.Init();
            //_uiMng.Init(); => look in UIManager describe
            _isFirstRun = false;
        }
        else
        {
            Player.Singltone.ResetPlayerForNewGame();
        }
    }
    public void PlayerCrush()
    {
        if (!Player.Singltone.IsCrush)
        {
            GameEvents.EventCrush.OnEvent();
            StartCoroutine(_gameOver.RestarLvl()); // реализовать подписку на событие столкновения игрока с препятствием
        }
    }
    #region InWork
    public void ChangeSpeed(float value)
    {
        _gameSpeed = value;
    }
    public void SetGamePause(GameObject menu)
    {
        Player.Singltone?.PlayerOff(); //Player Untying control
                                       //and Bind
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // Pause
        menu.SetActive(!menu.activeInHierarchy); //Active Menu

    }
    #endregion

    private void CheckSingltone()
    {
        if (Singltone == null)
        {
            Singltone = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

