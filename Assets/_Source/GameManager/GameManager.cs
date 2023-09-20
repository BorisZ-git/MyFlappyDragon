using UnityEngine;
#region ToDoList
/*
 * 1. Переписать Канвас под неуничтожимый объект
 * а. Переписать логику скриптов на канвасе под Init() - UIManager,UIMenu,
 * 2. Перебросить логику паузы по разным скриптам
 * 3. Создать UIEventHandler
 * 4. Перебросить логику Сложности на отдельный скрипт
 * 5. Отвязать игрока от Singltone? У геймменеджера есть ссылка на плеера зачем еще одна?(Инкапсулировать свойство Player для сеттера в прайват)
 * 6. Рефакторинг UIMenu
 * 7. Запись счета если побить рекорд при выходе(Создать событие выхода? добавить запись настроек игры?)
 * 8. Перекинуть логику инпутов на InputManager?
 */
#endregion
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
    private static Difficulty _currentDifficulty;

    public GameObject PlayerPrefab { get => _playerPrefab; }
    public GameObject ObstaclePrefab { get => _obstaclePrefab; }
    public Transform PlayerSpawn { get => _playerSpawn; }
    public Transform ObstacleSpawn { get => _obstacleSpawn; }
    public Player Player { get => _player; set => _player = value; }
    public GameScore GameScore { get => _gameScore; }
    public GameEventHandler GameEvents { get => _gameEventHandler; }
    public float GameSpeed { get => _gameSpeed; }
    public Difficulty CurrentDifficulty { get => _currentDifficulty; }

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
            _currentDifficulty = Difficulty.Normal;
            ChangeDifficulty(_currentDifficulty);
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
    public void ChangeSpeed(float value)
    {
        _gameSpeed = value;
    }
    public void ChangeDifficulty(Difficulty value)
    {
        switch (value)
        {
            case Difficulty.Easy:
                _gameSpeed = 1.5f;
                _gameScore.Points = 1;
                break;
            case Difficulty.Normal:
                _gameSpeed = 2.0f;
                _gameScore.Points = 5;
                break;
            case Difficulty.Hard:
                _gameSpeed = 2.5f;
                _gameScore.Points = 10;
                break;
            default:
                break;
        }
        _currentDifficulty = value;
    }
    public void SetGamePause(GameObject menu)
    {
        Player.Singltone?.PlayerOff(); //Player Untying control                                       
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // Pause
        menu.SetActive(!menu.activeInHierarchy); //Active Menu
    }
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

