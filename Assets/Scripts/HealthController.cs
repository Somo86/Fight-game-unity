using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public float initialLife = 100;
    [System.NonSerialized]
    public float maxLife = 100;
    [System.NonSerialized]
    public float currentLife;
    private LifeUIController lifeUI;

    void Awake()
    {
        if (initialLife > maxLife)
            initialLife = maxLife;

        currentLife = initialLife;
        lifeUI = gameObject.transform.Find("Canvas").GetComponent<LifeUIController>();
    }

    public void addLife(int value)
    {
        var newLife = currentLife + value;
        if (newLife >= maxLife)
            currentLife = maxLife;
        else
            currentLife = newLife;
        
        lifeUI.ShowWinPoints(value);
        UpdateBarLife();
    }

    public void removeLife(int value)
    {
        var newLife = currentLife - value;
        if (newLife <= 0)
        {
            var character = gameObject.GetComponent<CharacterController>();
            if(character.isHero)
            {
                var heroe = gameObject.GetComponent<HeroController>();
                heroe.OnDeath();
            } else {
                var enemy = gameObject.GetComponent<EnemyController>();
                enemy.OnDeath(gameObject);
            }
        }
        else
            currentLife = newLife;

        lifeUI.ShowLosePoints(value);
        UpdateBarLife();
    }

    private void UpdateBarLife()
    {
        var character = gameObject.GetComponent<CharacterController>();
        if(character.isHero)
        {
            var heroBar = gameObject.GetComponent<HeroBarLifeController>();
            heroBar.updateBarLength(currentLife);
        }
    }
}
