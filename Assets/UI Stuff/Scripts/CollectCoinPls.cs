using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoinPls : MonoBehaviour
{
    public int value = 5;
    [SerializeField] private AudioSource coinSound;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CountCoinsPls.instance.ChangeCoinCount(value);
            coinSound.Play();
        }
    }
}