using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanelSettings : MonoBehaviour
{
    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;


    [Header("Sliders")]
    [SerializeField] private Slider speedSlider1;
    [SerializeField] private Slider speedSlider2;

    [SerializeField] private TextMeshProUGUI SpeedValueP1;
    [SerializeField] private TextMeshProUGUI SpeedValueP2;

    [Header("Players")]
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    [Header("Button")]
    [SerializeField] private Button backSetButton;
    void Start()
    {
        backSetButton.onClick.AddListener(OnBackButtonClicked);
        speedSlider1.onValueChanged.AddListener(OnSpeedSliderChanged1);
        speedSlider2.onValueChanged.AddListener(OnSpeedSliderChanged2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        backSetButton.onClick.RemoveAllListeners();
        speedSlider1.onValueChanged.RemoveAllListeners();
        speedSlider2.onValueChanged.RemoveAllListeners();
    }

    private void OnSpeedSliderChanged1(float speed)
    {
        SpeedValueP1.text = speed.ToString("F2");
        player1.SetSpeed(speed);
    }
    private void OnSpeedSliderChanged2(float speed)
    {
        SpeedValueP2.text = speed.ToString("F2");
        player2.SetSpeed(speed);
    }
    private void OnBackButtonClicked()
    {
        pausePanel.SetActive(true);
        gameObject.SetActive(false);

    }

}
