using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [Header("Sliders")]
    [SerializeField] private Slider speedSlider1;
    [SerializeField] private Slider speedSlider2;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;

    [Header("Players")]
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;
    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);

        speedSlider1.onValueChanged.AddListener(OnSpeedSliderChanged1);
        speedSlider2.onValueChanged.AddListener(OnSpeedSliderChanged2);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
            }
        }

    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
    }
    private void OnPlayButtonClicked()
    {
        pausePanel.SetActive(false);
        Debug.Log("AAAAAAAAAA");
    }
    private void OnExitButtonClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnSpeedSliderChanged1(float speed)
    {
        player1.SetSpeed(speed);
    }
    private void OnSpeedSliderChanged2(float speed)
    {
        player2.SetSpeed(speed);
    }
}
