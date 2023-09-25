using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UIScore))] [RequireComponent(typeof(UIMenu))][RequireComponent(typeof(UIEvents))]
public sealed class UIManager : MonoBehaviour
{
    [SerializeField] private Image _darkEffect;
    private UIScore _uiScore;
    private UIMenu _uiMenu;
    private UIEvents _uiEvents;
    public UIScore UIScore { get => _uiScore; }
    public UIMenu UIMenu { get => _uiMenu; }

    public void Init()
    {
        InitComponents();
        EventSubscribe();
        DontDestroyOnLoad(this);
    }
    private void InitComponents()
    {
        _uiScore = GetComponent<UIScore>();
        _uiMenu = GetComponent<UIMenu>();
        _uiEvents = GetComponent<UIEvents>();
        _uiScore.Init();
        _uiMenu.Init();
        _uiEvents.Init(this);
    }
    private void EventSubscribe()
    {
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(SetDarkEffect);
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(SetDarkEffect);
    }
    private void SetDarkEffect()
    {
        if(_darkEffect != null)
            _darkEffect.gameObject.SetActive(!_darkEffect.gameObject.activeInHierarchy);
    }
}
