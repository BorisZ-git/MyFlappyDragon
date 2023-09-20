using UnityEngine;

public class LevelPreparing
{
    public void FillScene()
    {
        if (!Player.Singltone && GameManager.Singltone?.PlayerPrefab && GameManager.Singltone?.PlayerSpawn)
        {
            GameManager.Singltone.Player = Object.Instantiate(GameManager.Singltone.PlayerPrefab, GameManager.Singltone.PlayerSpawn.position, Quaternion.identity).GetComponent<Player>();
            GameManager.Singltone.Player.Init();
        }
        else if (Player.Singltone) // && _playerSpawn =>
        {
            Player.Singltone.transform.position = GameManager.Singltone?.PlayerSpawn != null ? GameManager.Singltone.PlayerSpawn.position : new Vector3(-1.5f, 0, 0);
        }
        else
        {
            Debug.Log("Check Settings in GameManager Prefabs");
        }

    }
    public void LoadGame()
    {
        Player.Singltone.Init();
    }
}
