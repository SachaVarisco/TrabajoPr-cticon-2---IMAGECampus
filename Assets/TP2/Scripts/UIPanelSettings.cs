using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPanelSettings : MonoBehaviour
{
    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;

    [Header("Sliders P1")]
    [SerializeField] private Slider speedSlider1;
    [SerializeField] private TextMeshProUGUI SpeedValueP1;
    [SerializeField] private Slider scaleSlider1; 
    [SerializeField] private TextMeshProUGUI scaleValueP1;
    [SerializeField] private Slider colorSlider1;
    [SerializeField] private Image colorValueP1;
    
    [Header("Sliders P2")]
    [SerializeField] private Slider speedSlider2;
    [SerializeField] private TextMeshProUGUI SpeedValueP2;
    [SerializeField] private Slider scaleSlider2;
    [SerializeField] private TextMeshProUGUI scaleValueP2;
    [SerializeField] private Slider colorSlider2;
    [SerializeField] private Image colorValueP2;
    
    [Header("Movement")]
    [SerializeField] private PlayerMove_TP3 playerMove1;
    [SerializeField] private PlayerMove_TP3 playerMove2;

    [Header("Scale")]
    [SerializeField] private TP3_PlayerScaleMod playerScale1;
    [SerializeField] private TP3_PlayerScaleMod playerScale2;

    [Header("Color")]
    [SerializeField] private TP3_PlayerColor playerColor1;
    [SerializeField] private TP3_PlayerColor playerColor2;


    [Header("Button")]
    [SerializeField] private Button backSetButton;
    private void Awake() {
        
    }
    void Start()
    {
        backSetButton.onClick.AddListener(OnBackButtonClicked);
        speedSlider1.onValueChanged.AddListener(OnSpeedSliderChanged1);
        speedSlider2.onValueChanged.AddListener(OnSpeedSliderChanged2);
        scaleSlider1.onValueChanged.AddListener(OnScaleSliderChanged1);
        scaleSlider2.onValueChanged.AddListener(OnScaleSliderChanged2);
        colorSlider1.onValueChanged.AddListener(OnColorSliderChanged1);
        colorSlider2.onValueChanged.AddListener(OnColorSliderChanged2);
    }

    private void OnDestroy()
    {
        backSetButton.onClick.RemoveAllListeners();
        speedSlider1.onValueChanged.RemoveAllListeners();
        speedSlider2.onValueChanged.RemoveAllListeners();
        scaleSlider1.onValueChanged.RemoveAllListeners();
        scaleSlider2.onValueChanged.RemoveAllListeners();
        colorSlider1.onValueChanged.RemoveAllListeners();
        colorSlider2.onValueChanged.RemoveAllListeners();
    }

    // Speed Functions
    private void OnSpeedSliderChanged1(float speed)
    {
        SpeedValueP1.text = speed.ToString();
        playerMove1.SetSpeed(speed);
    }
    private void OnSpeedSliderChanged2(float speed)
    {
        SpeedValueP2.text = speed.ToString();
        playerMove2.SetSpeed(speed);
    }

    // Scale functions
    private void OnScaleSliderChanged1(float scale)
    {
        scaleValueP1.text = scale.ToString("F2");
        playerScale1.SetScaleY(scale);
    }
    private void OnScaleSliderChanged2(float scale)
    {
        scaleValueP2.text = scale.ToString("F2");
        playerScale2.SetScaleY(scale);
    }

    // Color functions
    private void OnColorSliderChanged1(float color)
    {
        colorValueP1.color = Color.HSVToRGB(color, 1, 1);
        playerColor1.SetColor(color);
    }
    private void OnColorSliderChanged2(float color)
    {
        colorValueP2.color = Color.HSVToRGB(color, 1, 1);
        playerColor2.SetColor(color);
    }
    private void OnBackButtonClicked()
    {
        pausePanel.SetActive(true);
        gameObject.SetActive(false);

    }

}
