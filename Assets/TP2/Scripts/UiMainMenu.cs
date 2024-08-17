using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Pause Panel")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [Header("Settings Panel")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider speedSlider1;
    [SerializeField] private Slider speedSlider2;
    [SerializeField] private Button backSetButton;
    [SerializeField] private TextMeshProUGUI SpeedValueP1;
    [SerializeField] private TextMeshProUGUI SpeedValueP2;

    [Header("CreditsPanel")]
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private Button backCredButton;

    [Header("Players")]
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;
    private void Awake()
    {
        //Pause Panel
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSetButtonClicked);
        creditsButton.onClick.AddListener(OnCredButtonClicked);

        //Settings Panel
        backSetButton.onClick.AddListener(OnBackButtonClicked);
        speedSlider1.onValueChanged.AddListener(OnSpeedSliderChanged1);
        speedSlider2.onValueChanged.AddListener(OnSpeedSliderChanged2);

        //Credits Panel
        backCredButton.onClick.AddListener(OnBackButtonClicked);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                pausePanel.SetActive(true);
            }else{
                pausePanel.SetActive(false);
            }
        }

    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        backCredButton.onClick.RemoveAllListeners();
        backSetButton.onClick.RemoveAllListeners();
        
    }
    //Pause Functions
    private void OnPlayButtonClicked(){
        pausePanel.SetActive(false);
    }
    private void OnExitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnCredButtonClicked(){
        pausePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    private void OnSetButtonClicked(){
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    //Settings Functions
    private void OnSpeedSliderChanged1(float speed)
    {
        SpeedValueP1.text = speed.ToString();
        player1.SetSpeed(speed);
    }
    private void OnSpeedSliderChanged2(float speed)
    {
        SpeedValueP2.text = speed.ToString();
        player2.SetSpeed(speed);
    }
    private void OnBackButtonClicked(){
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
}
