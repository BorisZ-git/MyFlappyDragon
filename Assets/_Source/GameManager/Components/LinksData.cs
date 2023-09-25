using UnityEngine;

public class LinksData
{
    private Player _player;
    private UIManager _uiMng;
    private AudioManager _aMng;
    private MusicMng _musicMng;
    private GameObject _points;
    private static Vector3 _playerSpawn;
    private static Vector3 _obstacleSpawn;

    public Player Player { get => _player; }
    public UIManager UIMng { get => _uiMng; }
    public AudioManager AudioMng { get => _aMng; }
    public MusicMng MusicMng { get => _musicMng; }
    public Vector3 PlayerSpawn { get => _playerSpawn; }
    public Vector3 ObstacleSpawn { get => _obstacleSpawn; }

    public LinksData(Player player, UIManager uiMng, GameObject audioManager, GameObject points)
    {
        _player = player;
        _uiMng = uiMng;
        _aMng = audioManager.GetComponent<AudioManager>();
        _musicMng = audioManager.GetComponentInChildren<MusicMng>();
        _points = points;
        SetPoints();
    }
    private void SetPoints()
    {
        foreach (var item in _points.GetComponentsInChildren<Transform>())
        {
            if (item.CompareTag("Player"))
                _playerSpawn = item.position;
            else if (item.CompareTag("Respawn"))
                _obstacleSpawn = item.position;
        }
    }
}
