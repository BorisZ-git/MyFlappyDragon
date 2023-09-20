using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameScore
{
    private int _score;
    private int _bestScore;
    private const string _hashPathScoreFile = "Assets/Supporting/Score/Score.txt";
    public int BestScore { get => _bestScore; }
    public int Points { get; set; }
    public GameScore()
    {
        ReadBestScore();
        GameManager.Singltone.GameEvents.EventPassObstacle.Subscribe(AddScore);
        GameManager.Singltone.GameEvents.EventCrush.Subscribe(WriteScore);
    }
    private void AddScore()
    {
        _score += Points;
        SetNewBestScore();
    }
    private bool SetNewBestScore()
    {
        if (_score >= _bestScore)
        {
            _bestScore = _score;
            return true;
        }
        return false;
    }
    public string GetScore()
    {
        return $"Score: {_score}";
    }
    public string GetBestScore()
    {
        return $"BestScore: {_bestScore}";
    }
    public void ResetScore()
    {
        _score = 0;
    }
    private void WriteScore()
    {
        if (SetNewBestScore())
        {
            ReadWriteDataHelper.Write(_hashPathScoreFile, _score.ToString());
        }
    }
    private void ReadBestScore()
    {
        string temp = ReadWriteDataHelper.ReadSingle(_hashPathScoreFile);
        if (!Int32.TryParse(temp, out _bestScore) || temp == null)
        {
            Debug.Log("Wrong string in TryParse");
        }
    }
}

