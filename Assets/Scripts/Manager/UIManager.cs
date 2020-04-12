using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Singleton { get; private set; }

    public string MenuSceneName;

    [Header("Error UI")]
    [SerializeField] private GameObject ErrorUI;
    [SerializeField] private TextMeshProUGUI ErrorText ;
    [SerializeField] private bool AlwaysShowCursor = false ;

    [Header("Interact UI")]
    [SerializeField] private GameObject InteractUI ;

    [Header("End UI")]
    [SerializeField] private GameObject EndUI;

    [Header("Pause Menu")]
    [SerializeField] private GameObject PauseUI ;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShowErrorText(string ErrorName)
    {
        ErrorText.text = ErrorName;
        ShowErrorUI();
    }

    public void ShowErrorUI()
    {
        Time.timeScale = 0f;
        ErrorUI.SetActive(true);
        AudioManager.Singleton.PlayErrorSound();
        ShowCursor();
        Character.Singleton.DisableMove();
    }

    public void HideErrorUI()
    {
        Time.timeScale = 1f;
        ErrorUI.SetActive(false);
        HideCursor();
        Character.Singleton.AuthorizeMove();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        if(!AlwaysShowCursor)
        {
            Cursor.visible = false;
        }
    }

    public void ShowInteractIndication()
    {
        InteractUI.SetActive(true);
    }

    public void HideInteractIndication()
    {
        InteractUI.SetActive(false);
    }

    public void ShowEnd()
    {
        ShowCursor();
        EndUI.SetActive(true);
        Time.timeScale = 0;
        Character.Singleton.DisableMove();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }

    public void TogglePauseMenu()
    {
        if(PauseUI.activeSelf)
        {
            HidePauseMenu();
        }
        else
        {
            ShowPauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        ShowCursor();
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        Character.Singleton.DisableMove();
    }

    public void HidePauseMenu()
    {
        HideCursor();
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        Character.Singleton.AuthorizeMove();
    }
}
