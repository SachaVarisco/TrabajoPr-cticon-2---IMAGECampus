using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanelPause : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;


    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSetButtonClicked);
        creditsButton.onClick.AddListener(OnCredButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf && !creditsPanel.activeSelf && !settingsPanel.activeSelf)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                if (pausePanel.activeInHierarchy)
                {
                    pausePanel.SetActive(false);
                    Time.timeScale = 1f;
                }

            }
        }
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClicked()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void OnExitButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
    private void OnCredButtonClicked()
    {
        pausePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    private void OnSetButtonClicked()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

}
