using UnityEngine;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    [SerializeField] private GameObject _panelSettings;
   
    private void Awake()
    {
        _panelSettings.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Continue()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetMute(bool value)
    {
        var mute = value;
        AudioListener.pause= mute;
    }

    public void SetVolume(float value)
    {
        var volume = value/100;
        AudioListener.volume = volume;
    }

    public void ShowSettings()
    {
        _panelSettings.SetActive(true);
    }
}
