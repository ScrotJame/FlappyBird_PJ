using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManger : MonoBehaviour
{
    public static ScoreManger instance;
    private const string bestScore="Best Core";
    void isGameStartfirst()
    {
        if (!PlayerPrefs.HasKey("isGameStartfirst"))
        {
            PlayerPrefs.SetInt(bestScore, 0);
            PlayerPrefs.SetInt("isGameStartfirst", 0);
        }
    }
    private void Awake()
    {
        _ScoreInstance();
    }
    void _ScoreInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void setHighScore(int score)
    {
        PlayerPrefs.SetInt(bestScore, score);
    }
    public int getHighScore()
    {
        return PlayerPrefs.GetInt(bestScore);
    }
}
