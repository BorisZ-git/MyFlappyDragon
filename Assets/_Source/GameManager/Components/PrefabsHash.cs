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

    public GameObject PlayerPrefab { get => _playerPrefab; }
    public GameObject[] ObstaclePrefab { get => _obstaclePrefab; }
    public GameObject CanvasPrefab { get => _canvasPrefab; }
    public GameObject AudioMngPrefab { get => _audioMngPrefab; }
    public GameObject Points { get => _points; }

}
