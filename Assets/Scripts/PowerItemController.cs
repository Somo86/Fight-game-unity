using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItemController : MonoBehaviour
{
    public Elements itemPower;
    public float powerDurance = 2f;
    private AudioClip fireClip;
    private AudioClip lightClip;
    private AudioClip natureClip;
    private AudioClip waterClip;

    private void Awake()
    {
        fireClip = Resources.Load<AudioClip>("Sounds/fire");
        lightClip = Resources.Load<AudioClip>("Sounds/lighting");
        natureClip = Resources.Load<AudioClip>("Sounds/nature");
        waterClip = Resources.Load<AudioClip>("Sounds/water");
    }
    private void DelegatePower(GameObject hero)
    {
        var powerController = hero.GetComponent<HeroPowerController>();
        powerController.ActivePower(itemPower, powerDurance);
    }

    private void SoundEffect(AudioSource HeroAudio)
    {
        switch (itemPower)
        {
            case Elements.FIRE:
                HeroAudio.PlayOneShot(fireClip);
                break;
            case Elements.LIGHTING:
                HeroAudio.PlayOneShot(lightClip);
                break;
            case Elements.NATURE:
                HeroAudio.PlayOneShot(natureClip);
                break;
            case Elements.WATER:
                HeroAudio.PlayOneShot(waterClip);
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            DelegatePower(collision.gameObject);
            Destroy(gameObject);
            SoundEffect(collision.gameObject.GetComponent<AudioSource>());
        }
    }

}
