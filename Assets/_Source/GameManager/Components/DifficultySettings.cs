using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DifficultySettings
{
    private static GameScore _gameScore;
    private static Difficulty _currentDifficulty;
    public Difficulty CurrentDif { get => _currentDifficulty; }
    public DifficultySettings(GameScore gameScore, Difficulty difficulty = Difficulty.Normal)
    {
        _gameScore = gameScore;
        _currentDifficulty = difficulty;
        EventSubscribe();
    }
    private void EventSubscribe()
    {
        GameManager.Singltone.GameEvents.EventResetGame.Subscribe(SetDifficulty);
    }
    public void SetDifficulty(Difficulty value)
    {
        switch (value)
        {
            case Difficulty.Easy:
                GameManager.Singltone.ChangeSpeed(1.5f);
                _gameScore.Points = 1;
                break;
            case Difficulty.Normal:
                GameManager.Singltone.ChangeSpeed(2.0f);
                _gameScore.Points = 5;
                break;
            case Difficulty.Hard:
                GameManager.Singltone.ChangeSpeed(2.5f);
                _gameScore.Points = 10;
                break;
            default:
                break;
        }
        _currentDifficulty = value;
    }
    public void SetDifficulty()
    {
        switch (_currentDifficulty)
        {
            case Difficulty.Easy:
                GameManager.Singltone.ChangeSpeed(1.5f);
                _gameScore.Points = 1;
                break;
            case Difficulty.Normal:
                GameManager.Singltone.ChangeSpeed(2.0f);
                _gameScore.Points = 5;
                break;
            case Difficulty.Hard:
                GameManager.Singltone.ChangeSpeed(2.5f);
                _gameScore.Points = 10;
                break;
            default:
                break;
        }
    }
}
