using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public sealed class GameOver
{
    private float _timeToRestart;
    public GameOver(float timeToRestart)
    {
        _timeToRestart = timeToRestart;
    }
    private void RestartCurrentLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public IEnumerator RestarLvl()
    {
        float temp = GameManager.Singltone.GameSpeed;
        GameManager.Singltone.ChangeSpeed(0);
        yield return new WaitForSeconds(_timeToRestart);
        GameManager.Singltone.GameScore.ResetScore();
        GameManager.Singltone.ChangeSpeed(temp);        
        RestartCurrentLvl();
    }
}
