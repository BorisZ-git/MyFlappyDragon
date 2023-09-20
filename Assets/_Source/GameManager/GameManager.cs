using UnityEngine;
#region ToDoList
/*
 * 1. Переписать Канвас под неуничтожимый объект
 * а. Переписать логику скриптов на канвасе под Init() - UIManager,UIMenu,
 * Задать проверку на инициализированные компоненты и подписки в компонентах GameManagera _isInit;
 * б. UIMENU теряет ссылки на audioMng так как отдельный объект
 * в. Obstacle 31 строка потеря объекта spawnPoint, так как сериализован. Ссылка через GameManager
 * 2. Перебросить логику паузы по разным скриптам
 * 3. Создать UIEventHandler
 * 4. Перебросить логику Сложности на отдельный скрипт
 * 5. Отвязать игрока от Singltone? У геймменеджера есть ссылка на плеера зачем еще одна?(Инкапсулировать свойство Player для сеттера в прайват)
 * 6. Рефакторинг UIMenu
 * 7. Запись счета если побить рекорд при выходе(Создать событие выхода? добавить запись настроек игры?)
 * 8. Перекинуть логику инпутов на InputManager?
 */
#endregion
[RequireComponent(typeof(PrefabsHash))]
public sealed class GameManager : MonoBehaviour
{
    public static GameManager Singltone;

    [Header("Game Settings")]
    [SerializeField][Tooltip("How fast obstacles moving")][Range(1,4)] private float _gameSpeed;
    [SerializeField] private float _timeToRestart;

    private static LevelPreparing _levelPreparing;
    private static GameScore _gameScore;
    private static GameOver _gameOver;
    private static GameEventHandler _gameEventHandler;
    private static LinksData _linksData;
    private static PrefabsHash _prefabsHash;

    private static bool _isFirstRun = true;
    private static Difficulty _currentDifficulty;

    public LinksData LinksData { get => _linksData; }
    public PrefabsHash PrefabsHash { get => _prefabsHash; }
    public GameScore GameScore { get => _gameScore; }
    public GameEventHandler GameEvents { get => _gameEventHandler; }
    public float GameSpeed { get => _gameSpeed; }
    public Difficulty CurrentDifficulty { get => _currentDifficulty; }

    private void Awake()
    {
        CheckSingltone();
        if (_isFirstRun)
            InitManager();
        else
            ResetGame();
        LoadGame();
    }
    private void LoadGame()
    {
        LinksData.UIMng.Init();

    }
    private void InitManager()
    {
        _prefabsHash = GetComponent<PrefabsHash>();
        _levelPreparing = new LevelPreparing();
        _gameEventHandler = new GameEventHandler();
        _gameScore = new GameScore();
        _gameOver = new GameOver(_timeToRestart);
        _prefabsHash.Init();
        _linksData = _levelPreparing.FillScene();
        LinksData.Player.Init();
        _currentDifficulty = Difficulty.Normal;
        ChangeDifficulty(_currentDifficulty);
        _isFirstRun = false;
    }
    private void ResetGame()
    {
        LinksData.Player.transform.position = PrefabsHash.PlayerSpawn;
        LinksData.Player.ResetPlayerForNewGame();
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

