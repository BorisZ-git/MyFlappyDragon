using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] [RequireComponent(typeof(PlayerMovement))] [RequireComponent(typeof(PlayerAnim))]
public class Player : MonoBehaviour
{
    public static Player Singltone { get; private set; }
    private Rigidbody2D _playerRB;
    private PlayerControl _playerControl;
    private PlayerMovement _playerMove;
    private PlayerAnim _playerAnim;
    private bool _isRequirCompSet;
    private bool _isCrush;
    private bool _isPlayerOn;
    public Rigidbody2D PlayerRB { get => _playerRB; }
    public PlayerMovement PlayerMove { get => _playerMove; }
    public bool IsCrush { get => _isCrush; }

    public void Init()
    {
        CheckSingltone();
        if (!_isRequirCompSet)
        {
            _playerRB = GetComponent<Rigidbody2D>();
            _playerMove = GetComponent<PlayerMovement>();
            _playerAnim = GetComponent<PlayerAnim>();
            _playerControl = new PlayerControl();
            _playerMove.Init();
            _playerAnim.Init();
            GameManager.Singltone?.GameEvents?.EventCrush?.Subscribe(Crush); // возможно лучше сделать из другого места
        }
    }
    public void Crush()
    {
        _isCrush = true;
        _playerControl.Untying();
        GetComponent<Collider2D>().enabled = false;
        _playerAnim.PlayCrushAnim();
    }
    public void ResetPlayerForNewGame()
    {
        Debug.Log("ResetPlayer");
        _isCrush = false;
        GetComponent<Collider2D>().enabled = true;
        _playerControl.Bind();
        _playerAnim.ResetCrushAnim();
        ResetRBForce();
    }
    public bool PlayerOff()
    {
        _playerControl.Untying();
        
        return _isPlayerOn = !_isPlayerOn;
    }
    private void ResetRBForce()
    {
        _playerRB.isKinematic = true;
        _playerRB.velocity = Vector2.zero;
        _playerRB.isKinematic = false;
    }
    private void CheckSingltone()
    {
        if (Singltone == null)
        {
            Singltone = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Singltone._isRequirCompSet = true; // ќсобенность инкапсул€ции в C# - инкапсул€ции на уровни классов, а не объектов. ѕозвол€ет мен€ть внутри класса приватные переменные других объектов.
            //Destroy(this.gameObject);
        }
    }
}
