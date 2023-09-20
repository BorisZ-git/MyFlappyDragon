using UnityEngine;

public class LevelPreparing
{
    public LinksData FillScene()
    {
        LinksData data = new LinksData
            (
            LoadPlayer(),
            LoadCanvas(),
            LoadAudioMng()
            );        
        return data;
    }
    private Player LoadPlayer()
    {
        if (GameManager.Singltone.PrefabsHash.PlayerPrefab == null || GameManager.Singltone.PrefabsHash.PlayerSpawn == null) Debug.Log("Prefab null");
        return Object.Instantiate(GameManager.Singltone.PrefabsHash.PlayerPrefab, GameManager.Singltone.PrefabsHash.PlayerSpawn, Quaternion.identity).GetComponent<Player>();
    }
    private UIManager LoadCanvas()
    {
        if (GameManager.Singltone.PrefabsHash.CanvasPrefab == null) Debug.Log("Prefab null");
        return Object.Instantiate(GameManager.Singltone.PrefabsHash.CanvasPrefab).GetComponent<UIManager>();
    }
    private GameObject LoadAudioMng()
    {
        if (GameManager.Singltone.PrefabsHash.AudioMngPrefab == null) Debug.Log("Prefab null");
        return Object.Instantiate(GameManager.Singltone.PrefabsHash.AudioMngPrefab);
    }
}
