using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(UIManager))]
public class UIScore : DestoyedEventObj
{
    [Header("Links")]
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;
    public void Init()
    {
        UpdateUI();
        //GameManager.Singltone.GameEvents?.EventPassObstacle?.Subscribe(UpdateUI);
    }
    private void UpdateUI()
    {
        if(_score != null)
            _score.text = GameManager.Singltone?.GameScore?.GetScore();
        if (_bestScore != null)
            _bestScore.text = GameManager.Singltone?.GameScore?.GetBestScore();
    }
    protected override void SetEventActionData()
    {
        _eventAction = new List<EventActionData>();
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventPassObstacle, UpdateUI));
    }
}
