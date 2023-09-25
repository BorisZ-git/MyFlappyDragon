using UnityEngine;

public class LevelPreparing
{
    /// <summary>
    /// Instantiate prefabs on Scene and return links on they
    /// </summary>
    /// <returns>Links of instantiate objects</returns>
    public LinksData FillScene()
    {
        LinksData data = new LinksData
            (
            LoadPlayer(),
            LoadCanvas(),
            LoadAudioMng(),
            LoadPoints()
            );        
        return data;
    }
    private Player LoadPlayer()
    {
        if (GameManager.Singltone.PrefabsHash.PlayerPrefab == null) Debug.Log("Prefab null");
        return Object.Instantiate(GameManager.Singltone.PrefabsHash.PlayerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
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
    private GameObject LoadPoints()
    {
        if (GameManager.Singltone.PrefabsHash.Points == null) Debug.Log("Prefab null");
        GameObject temp = (Object.Instantiate(GameManager.Singltone.PrefabsHash.Points));
        Object.DontDestroyOnLoad(temp);
        return temp;
    }
}
