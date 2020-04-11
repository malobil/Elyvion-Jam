using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Singleton { get; private set; }

    [Header("Error UI")]
    [SerializeField] private GameObject ErrorUI;
    [SerializeField] private TextMeshProUGUI ErrorText ;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void HideErrorUI()
    {
        Time.timeScale = 1f;
        ErrorUI.SetActive(false);
    }
}
