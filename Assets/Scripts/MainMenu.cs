using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("level");

    }

    public void CloseGame(){
        Application.Quit();
    }

    public void Infinity(){
        SceneManager.LoadScene("Infinity");
    }
}
