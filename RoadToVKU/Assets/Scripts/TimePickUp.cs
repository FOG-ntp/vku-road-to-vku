using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : MonoBehaviour
{
    private TimeManager timeSystem;
    //public AudioSource powerupSoundEffect;

    // Use this for initialization
    void Start()
    {
        timeSystem = FindObjectOfType<TimeManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            timeSystem.GiveTime();
            Debug.Log("picked up life");
            //this.powerupSoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
