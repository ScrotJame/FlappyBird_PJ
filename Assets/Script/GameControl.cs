using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField ] Text ScoreTxt, EndScoreTxt, BestScoreTxt;
    [SerializeField] GameObject _GameOver;
    public static GameController GameControlInstant;
    public Button AgianButt, BackHomeButt;
    private void Start()
    {
        if (_GameOver == null)
        {            
            return;
        }
        _GameOver.SetActive(false);
    }
    private void Awake()
    {
        _MakeGameControlInstant();
    }
    public void getScore( int score)
    {
        ScoreTxt.text = score.ToString();
    }
    public void getGameOver(int score)
    {
        _GameOver.SetActive(true);
        EndScoreTxt.text = score.ToString();
        BestScoreTxt.text = score.ToString();
        if (score> ScoreManger.instance.getHighScore())
        {
            ScoreManger.instance.setHighScore(score);
        }
        BestScoreTxt.text = "" + ScoreManger.instance.getHighScore();
    }
    public void _Again()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void _Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void _MakeGameControlInstant()
    {
        if (GameControlInstant == null)
        {
            GameControlInstant=this;
        }
    }
}
