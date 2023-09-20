using UnityEngine;

[RequireComponent(typeof(GameManager))]
public sealed class PrefabsHash : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private GameObject _canvasPrefab;
    [SerializeField] private GameObject _audioMngPrefab;
    [Header("Spawn Points")]
    [SerializeField] private GameObject _points;
    private static Vector3 _playerSpawn;
    private static Vector3 _obstacleSpawn;
    public GameObject PlayerPrefab { get => _playerPrefab; }
    public GameObject[] ObstaclePrefab { get => _obstaclePrefab; }
    public GameObject CanvasPrefab { get => _canvasPrefab; }
    public GameObject AudioMngPrefab { get => _audioMngPrefab; }
    public Vector3 PlayerSpawn { get => _playerSpawn; }
    public Vector3 ObstacleSpawn { get => _obstacleSpawn; }
    public void Init()
    {
        DontDestroyOnLoad(Object.Instantiate(_points));
        foreach (var item in _points.GetComponents<Transform>())
        {
            if (item.CompareTag("Player"))
                _playerSpawn = item.position;
            else if (item.CompareTag("Respawn"))
                _obstacleSpawn = item.position;
        }
    }
}
