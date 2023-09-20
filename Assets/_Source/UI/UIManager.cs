using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIScore))] [RequireComponent(typeof(UIMenu))]
public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private Image _darkEffect;
    private UIScore _uiScore;
    private UIMenu _uiMenu;
    private static bool _isInit;
    public UIScore UIScore { get => _uiScore; }
    public UIMenu UIMenu { get => _uiMenu; }

    public void Init()
    {
        if (_darkEffect.gameObject.activeInHierarchy) SetDarkEffect();
        _uiScore = GetComponent<UIScore>();
        _uiMenu = GetComponent<UIMenu>();
        _uiScore.Init();
        _uiMenu.Init();
        if (_isInit) return;
        Bind();
        _isInit = true;
        DontDestroyOnLoad(this);
    }
    private void Bind()
    {
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(SetDarkEffect);
    }
    private void SetDarkEffect()
    {
        if(_darkEffect != null)
            _darkEffect.gameObject.SetActive(!_darkEffect.gameObject.activeInHierarchy);
    }
}
