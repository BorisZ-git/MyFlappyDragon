using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _flyForce = 5f;
    //private Player _player;
    //public void Init(Player player)
    //{
    //    _player = player;
    //}
    public void Init()
    {
        GameManager.Singltone.GameEvents.EventFly.Subscribe(FlyUp);
    }
    public void FlyUp()
    {
        Player.Singltone.PlayerRB.AddForce(Vector2.up * _flyForce, ForceMode2D.Impulse);
    }
}
