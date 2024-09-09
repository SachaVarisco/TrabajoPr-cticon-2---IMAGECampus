using UnityEngine;
using UnityEngine.UI;

public class PU_Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield1;
    [SerializeField] private GameObject shield2;

    [Header ("Advice")]
    [SerializeField] private Sprite word;
    [SerializeField] private GameObject advice;
    private Image image;

    private void Awake() {
        image = advice.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
       image.sprite = word;
       advice.SetActive(true);


        shield1.SetActive(true);
        shield2.SetActive(true);
        gameObject.SetActive(false);
    }
}
