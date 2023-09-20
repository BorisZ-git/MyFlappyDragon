using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))] [RequireComponent(typeof(Animator))]
public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _hashCrushAnim;
    public void Init()
    {
        if(_animator == null)
            _animator = GetComponent<Animator>();
    }
    public void PlayCrushAnim()
    {
        _animator.SetBool(_hashCrushAnim, true);
    }
    public void ResetCrushAnim()
    {
        _animator.SetBool(_hashCrushAnim, false);
    }
}
