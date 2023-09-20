using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksData
{
    private Player _player;
    private UIManager _uiMng;
    private AudioManager _aMng;
    private MusicMng _musicMng;

    public Player Player { get => _player; }
    public UIManager UIMng { get => _uiMng; }
    public AudioManager AudioMng { get => _aMng; }
    public MusicMng MusicMng { get => _musicMng; }

    public LinksData(Player player, UIManager uiMng, GameObject audioManager)
    {
        _player = player;
        _uiMng = uiMng;
        _aMng = audioManager.GetComponent<AudioManager>();
        _musicMng = audioManager.GetComponentInChildren<MusicMng>();
    }
}
