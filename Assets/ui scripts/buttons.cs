using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    [SerializeField] private GameObject panelofmainmenu;
    [SerializeField] private GameObject panelsettings;
    [SerializeField] private GameObject logopanel;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSettings()
    {
        panelofmainmenu.SetActive(false);
        logopanel.SetActive(false);
        panelsettings.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
