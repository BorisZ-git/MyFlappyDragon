using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(UIScore))] [RequireComponent(typeof(UIMenu))]
public class UIManager : DestoyedEventObj
{
    [SerializeField] private UIScore _uiScore;
    [SerializeField] private Image _darkEffect;

    public UIScore UIScore { get => _uiScore; }
    // ������� ������ ��������� � ������, ������������ ���� � ���� �������� � gamemanger � ����� ���� ��������� ���� ������ �� �����, ������� �������� �� ������ ������ � ����������� ��� �������
    // �� ������ ��� ���� � ����������� ��� ����������� ������ � ������ �������� ������� gamemanager �������� ����� ���������
    //public void Init()
    //{
    //    _uiScore = GetComponent<UIScore>();
    //    _uiScore.Init();
    //    DontDestroyOnLoad(this);
    //}

    public void SetDarkEffect()
    {
        if(_darkEffect != null)
            _darkEffect.gameObject.SetActive(true);
    }

    protected override void SetEventActionData()
    {
        _uiScore = GetComponent<UIScore>();
        _uiScore.Init();
        _eventAction = new List<EventActionData>();
        _eventAction.Add(new EventActionData(GameManager.Singltone.GameEvents.EventCrush, SetDarkEffect));
    }
    //IEnumerator SetEffectCoroutineTest()
    //{
    //    _darkEffect.color.a = ..
    //    yield return new WaitForSeconds(2f);
    //}
}
