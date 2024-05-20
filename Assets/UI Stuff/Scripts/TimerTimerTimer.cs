using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTimerTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countdownText;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject inGamePanel;

    [SerializeField] private MonoBehaviour carController;

    [SerializeField] private TextMeshProUGUI sourceText;
    [SerializeField] private TextMeshProUGUI destinationText;

    // Add two new GameObjects
    [SerializeField] private GameObject objectWhenGreaterThan100;
    [SerializeField] private GameObject objectWhenLessThan100;

    private float countdownTime = 64;
    void Start()
    {
        countdownText.text = countdownTime.ToString();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (countdownTime >= 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownText.text = countdownTime.ToString();

            if (countdownTime == 0)
            {
                Debug.Log("Countdown hit 0");
                gameOverPanel.SetActive(true);
                inGamePanel.SetActive(false);
                carController.enabled = false;
                //Time.timeScale = 0;

                // Copy text from source to destination
                destinationText.text = sourceText.text;

                // Check the value of destinationText and activate the appropriate GameObject
                int destinationValue;
                if (int.TryParse(destinationText.text, out destinationValue))
                {
                    if (destinationValue >= 100)
                    {
                        objectWhenGreaterThan100.SetActive(true);
                    }
                    else
                    {
                        objectWhenLessThan100.SetActive(true);
                    }
                }
            }
        }
    }
}