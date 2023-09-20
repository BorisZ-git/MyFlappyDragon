using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Supporting.Utils.IsInLayer(collision.gameObject.layer, _playerLayer))
        {
            GameManager.Singltone.PlayerCrush();
        }
    }
}
