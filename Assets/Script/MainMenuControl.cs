using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void _PlayButton()
    {
        //Application.LoadLevel("GameplayScene");
        SceneManager.LoadScene("GameplayScene");
    }
}
