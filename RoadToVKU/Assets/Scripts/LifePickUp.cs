using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour
{
    private LifeManager lifeSystem;
    //public AudioSource powerupSoundEffect;

    // Use this for initialization
    void Start()
    {
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            lifeSystem.GiveLife();
            Debug.Log("picked up life");
            //this.powerupSoundEffect.Play();
            Destroy(gameObject);
        }
    }
}