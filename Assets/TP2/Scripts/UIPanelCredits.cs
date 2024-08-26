using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelCredits : MonoBehaviour
{
    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;

    [Header("Buttons")]
    [SerializeField] private Button backCredButton;

    void Start()
    {
        backCredButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy()
    {
        backCredButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClicked()
    {
        pausePanel.SetActive(true);
        gameObject.SetActive(false);

    }
}
