using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour
{
	public void PlayGame()
    {
        SceneManager.LoadScene(SceneNames.MAINSCENE);
    }

    public void CharacterSelection()
    {
        SceneManager.LoadScene(SceneNames.CHARACTERSELECTIONSCENE);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(SceneNames.INSTRUCTIONSSCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }
}