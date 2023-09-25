using UnityEngine;
#region ToDoList
/*
 * 1.Разгрузить GameManager:
 * a. Снести методы не касающиеся загрузки сцены(PlayerCrysh,ChangeSpeed,ChangeDifficulty,SetGamePause) в отдельный скрипт типа GameControl(GameBahaviour).
 * Сделать на него свойство и давать доступ к его методам.
 * б. Разбить инициализацию на несколько методов, раскидать логически вызовы методов и объявление переменных.
 * в. Создать общий класс для некоторых полей
 * 2.Добавить отдельный UIEventsHandler для кнопок? Мне кажется что хорош уже с событиями играться и оставить можно и так
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
    private static UIEventHandler _uiEventHandler;
    private static LinksData _linksData;
    private static PrefabsHash _prefabsHash;
    private static DifficultySettings _difficultySettings;
    private static InputManager _inputMng;

    private static bool _isFirstRun = true;

    public LinksData LinksData { get => _linksData; }
    public PrefabsHash PrefabsHash { get => _prefabsHash; }
    public GameScore GameScore { get => _gameScore; }
    public GameEventHandler GameEvents { get => _gameEventHandler; }
    public UIEventHandler UIEvents { get => _uiEventHandler; }
    public DifficultySettings DifficultySettings { get => _difficultySettings; }
    public float GameSpeed { get => _gameSpeed; }

    private void Awake()
    {
        CheckSingltone();
        if (_isFirstRun)
        {
            InitManager();
            LoadGame();
            _isFirstRun = false;
        }
        else
            ResetGame();
    }
    private void InitManager()
    {
        _prefabsHash = GetComponent<PrefabsHash>();
        _levelPreparing = new LevelPreparing();
        _gameEventHandler = new GameEventHandler();
        _uiEventHandler = new UIEventHandler();
        _inputMng = new InputManager();
        _gameScore = new GameScore();
        _gameOver = new GameOver(_timeToRestart);
        _difficultySettings = new DifficultySettings(_gameScore);        
    }
    private void LoadGame()
    {
        _linksData = _levelPreparing.FillScene();
        LinksData.Player.transform.position = LinksData.PlayerSpawn;
        LinksData.Player.Init();
        LinksData.UIMng.Init();
        LinksData.AudioMng.Init();
        _difficultySettings.SetDifficulty();
    }
    private void ResetGame()
    {
        LinksData.Player.transform.position = LinksData.PlayerSpawn;
        GameEvents.EventResetGame.OnEvent();
    }
    public void PlayerCrush()
    {
        if (!LinksData.Player.IsCrush)
        {
            GameEvents.EventCrush.OnEvent();
            StartCoroutine(_gameOver.RestarLvl()); // реализовать подписку на событие столкновения игрока с препятствием(инкапсулировать перезагрузку уровня)
        }
    }
    public void ChangeSpeed(float value)
    {
        _gameSpeed = value;
    }
    public void ChangeDifficulty(Difficulty value)
    {
        _difficultySettings.SetDifficulty(value);
    }
    public void SetGamePause(GameObject menu)
    {
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