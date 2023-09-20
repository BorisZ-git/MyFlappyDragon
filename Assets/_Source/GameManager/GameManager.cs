using UnityEngine;
#region ToDoList
/*
 * 1. ���������� ������ ��� ������������� ������
 * �. ���������� ������ �������� �� ������� ��� Init() - UIManager,UIMenu,
 * ������ �������� �� ������������������ ���������� � �������� � ����������� GameManagera _isInit;
 * �. UIMENU ������ ������ �� audioMng ��� ��� ��������� ������
 * �. Obstacle 31 ������ ������ ������� spawnPoint, ��� ��� ������������. ������ ����� GameManager
 * 2. ����������� ������ ����� �� ������ ��������
 * 3. ������� UIEventHandler
 * 4. ����������� ������ ��������� �� ��������� ������
 * 5. �������� ������ �� Singltone? � ������������� ���� ������ �� ������ ����� ��� ����?(��������������� �������� Player ��� ������� � �������)
 * 6. ����������� UIMenu
 * 7. ������ ����� ���� ������ ������ ��� ������(������� ������� ������? �������� ������ �������� ����?)
 * 8. ���������� ������ ������� �� InputManager?
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
            StartCoroutine(_gameOver.RestarLvl()); // ����������� �������� �� ������� ������������ ������ � ������������
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

