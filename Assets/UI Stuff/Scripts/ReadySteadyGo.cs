using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadySteadyGo : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject StartPanelToDeactivate;
    public GameObject inGamePanelToActivate;
    public Image PanelOverlayImage;
    public AudioSource inGameAudioSource;
    [SerializeField] private MonoBehaviour PlayerControlsToToggle;

    private void Start()
    {
        PlayerControlsToToggle.enabled = false;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdownText.text = "Ready!";
        UpdateImageAlpha(0.8f);
        yield return new WaitForSeconds(1);
        countdownText.text = "3";
        UpdateImageAlpha(0.6f);
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        UpdateImageAlpha(0.4f);
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        UpdateImageAlpha(0.2f);
        yield return new WaitForSeconds(1);
        countdownText.text = "Go!";
        UpdateImageAlpha(0f);
        inGameAudioSource.Play();
        yield return new WaitForSeconds(1);
        inGamePanelToActivate.SetActive(true);
        StartPanelToDeactivate.SetActive(false);
        PlayerControlsToToggle.enabled = true;
    }

    void UpdateImageAlpha(float alpha)
    {
        Color color = PanelOverlayImage.color;
        color.a = alpha;
        PanelOverlayImage.color = color;
    }
}