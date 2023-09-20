using UnityEngine;
using TMPro;
[RequireComponent(typeof(UIManager))]
public class UIScore : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;
    private bool _isInit;
    public void Init()
    {
        UpdateUI();
        if (_isInit) return;
        GameManager.Singltone.GameEvents.EventPassObstacle.Subscribe(UpdateUI);
        _isInit = true;
    }
    private void UpdateUI()
    {
        if(_score != null)
            _score.text = GameManager.Singltone?.GameScore?.GetScore();
        if (_bestScore != null)
            _bestScore.text = GameManager.Singltone?.GameScore?.GetBestScore();
    }
}
