using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Respawn Logic")]
    [SerializeField] private bool _isRandomYOnRespawn;
    [SerializeField][Tooltip("Max Y value for offset on spawn")][Range(1,4.2f)] private float _maxYOffset;
    [Header("Trigger Layers")]
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _respawnLayer;
    private Vector3 _offsetY = new Vector3(0,0,0);


    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += Vector3.left * GameManager.Singltone.GameSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Supporting.Utils.IsInLayer(collision.gameObject.layer,_playerLayer))
        {
            GameManager.Singltone.GameEvents?.EventPassObstacle?.OnEvent();
        }
        else if(Supporting.Utils.IsInLayer(collision.gameObject.layer, _respawnLayer))
        {
            if (_isRandomYOnRespawn) RandomYPos();
            else transform.position = GameManager.Singltone.LinksData.ObstacleSpawn;            
        }
    }
    private void RandomYPos()
    {
        _offsetY.y = Random.Range(0, _maxYOffset);
        if(transform.position.y <= 0)
        {
            transform.position = GameManager.Singltone.LinksData.ObstacleSpawn + _offsetY;
        }
        else
        {
            transform.position = GameManager.Singltone.LinksData.ObstacleSpawn - _offsetY;
        }
    }
}
