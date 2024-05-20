using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadySteadyGo : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject StartPanelToDeactivate;
    public Image PanelOverlayImage;
    [SerializeField] private MonoBehaviour PlayerControlsToToggle; // Add this line

    private void Start()
    {
        PlayerControlsToToggle.enabled = false; // Deactivate the script on start
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
        yield return new WaitForSeconds(1);
        StartPanelToDeactivate.SetActive(false);
        PlayerControlsToToggle.enabled = true; // Activate the script after "Go!" text
    }

    void UpdateImageAlpha(float alpha)
    {
        Color color = PanelOverlayImage.color;
        color.a = alpha;
        PanelOverlayImage.color = color;
    }
}