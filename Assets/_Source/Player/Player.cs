using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] [RequireComponent(typeof(Collider2D))] [RequireComponent(typeof(PlayerMovement))] [RequireComponent(typeof(PlayerAnim))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private PlayerMovement _playerMove;
    private PlayerAnim _playerAnim;
    private Collider2D _playerCollider;
    private bool _isCrush;
    public Rigidbody2D PlayerRB { get => _playerRB; }
    public PlayerMovement PlayerMove { get => _playerMove; }
    public bool IsCrush { get => _isCrush; }

    public void Init()
    {
        SetPlayerComponents();
        InitAdditionalClasses();
        EventSubscribe();
        DontDestroyOnLoad(this);
    }
    private void InitAdditionalClasses()
    {
        _playerMove.Init(this);
        _playerAnim.Init();
    }
    private void SetPlayerComponents()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerMove = GetComponent<PlayerMovement>();
        _playerAnim = GetComponent<PlayerAnim>();
        _playerCollider = GetComponent<Collider2D>();
    }
    private void EventSubscribe()
    {
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(ResetPlayerForNewGame);
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(Crush);
    }
    public void Crush()
    {
        _isCrush = true;
        _playerCollider.enabled = false;
        _playerAnim.PlayCrushAnim();
    }
    public void ResetPlayerForNewGame()
    {
        _isCrush = false;
        _playerCollider.enabled = true;
        _playerAnim.ResetCrushAnim();
        ResetRBForce();
    }
    private void ResetRBForce()
    {
        _playerRB.isKinematic = true;
        _playerRB.velocity = Vector2.zero;
        _playerRB.isKinematic = false;
    }
}
