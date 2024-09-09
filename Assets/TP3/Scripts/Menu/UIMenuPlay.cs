using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuPlay : MonoBehaviour
{
    private Button playButton;
    private void Awake()
    {
        playButton = GetComponent<Button>();
    }
    private void Start() {
        playButton.onClick.AddListener(PlayGame);
    }
    private void PlayGame(){
        SceneManager.LoadScene("TP3_Game");
    }
}
