using UnityEngine;
using UnityEngine.UIElements;

public class readybutton : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
