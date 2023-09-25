using UnityEngine;
using TMPro;
[RequireComponent(typeof(UIManager))]
public class UIScore : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;
    public void Init()
    {
        UpdateUI();
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(UpdateUI);
        GameManager.Singltone.GameEvents.EventPassObstacle.Subscribe(UpdateUI);
    }
    private void UpdateUI()
    {
        if(_score != null)
            _score.text = GameManager.Singltone?.GameScore?.GetScore();
        if (_bestScore != null)
            _bestScore.text = GameManager.Singltone?.GameScore?.GetBestScore();
    }
}
