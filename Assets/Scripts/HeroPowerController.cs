using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPowerController : MonoBehaviour
{
    private Elements activePower = Elements.NONE;
    private ElementsPowerController elementsController;

    private void Awake()
    {
        elementsController = gameObject.GetComponent<ElementsPowerController>();
    }

    public void ActivePower(Elements power, float Durance)
    {
        activePower = power;
        Invoke(nameof(LosePower), Durance);
    }

    private void LosePower()
    {
        activePower = Elements.NONE;
        elementsController.DestroyActiveEffect();
    }

    // FIRE ENHANCE ***************************************
    private int TotalFireHits = 4;
    private int FireDamage = 5;
    private float LapseBetweenHits = 3f;

    private void FireEnhance(GameObject oponent)
    {
        var Enemy = oponent.GetComponent<EnemyController>();
        // Extra damage during time
        var EnemyHealth = oponent.GetComponent<HealthController>();
        var Poison = oponent.GetComponent<EnemyPoisonedController>();
        if(!Enemy.isPoisoned)
        {
            Poison.poisonWith(Elements.FIRE);
            Enemy.isPoisoned = true;
            // Restore
            StartCoroutine(DamageOverTime(EnemyHealth, Poison, Enemy));
        }
    }

    // Damage 4 times each 3 seconds
    private IEnumerator DamageOverTime(HealthController EnemyHealth, EnemyPoisonedController Poison, EnemyController Enemy)
    {
        var dotHits = 0;
        while (dotHits < TotalFireHits)
        {
            EnemyHealth.removeLife(FireDamage);
            dotHits ++;
            yield return new WaitForSeconds(LapseBetweenHits);
        }
        Poison.DestroyPoison();
        Enemy.isPoisoned = false;
    }
    // ********************************************

    // LIGHTING ENHANCE ***************************************
    private float LightingEnhanceDurance = 8f;
    private float TimeToFlip = 10f;

    private void LightingEnhance(GameObject oponent)
    {
        // Turn slower. Flip takes 10s
        var Enemy = oponent.GetComponent<EnemyController>();
        var Poison = oponent.GetComponent<EnemyPoisonedController>();
        if(!Enemy.isPoisoned)
        {
            Poison.poisonWith(Elements.LIGHTING);
            Enemy.isPoisoned = true;
            var originalFlipTime = Enemy.TimeToFlip;
            Enemy.TimeToFlip = TimeToFlip; // new time
            //Restore
            StartCoroutine(RestoreFlipTime(Enemy, originalFlipTime, Poison));
        }
    }

    private IEnumerator RestoreFlipTime(EnemyController Enemy, float originalFlipTime, EnemyPoisonedController Poison)
    {
        yield return new WaitForSeconds(LightingEnhanceDurance);
        Poison.DestroyPoison();
        Enemy.isPoisoned = false;
        Enemy.TimeToFlip = originalFlipTime; // restore original time
    }
    // ******************************************************

    // NATURE ENHANCE ***************************************
    private int NatureSanitze = 5;

    private void NatureEnhance(GameObject ownSelf)
    {
        // Sanitizing attacks
        var OwnHealth = ownSelf.GetComponent<HealthController>();
        OwnHealth.addLife(NatureSanitze);
    }
    // ******************************************************
    // WATER ENHANCE ***************************************
    private float WaterDurance = 8f;

    private void WaterEnhance(GameObject oponent)
    {
        // enemy cannot attack
        var Enemy = oponent.GetComponent<EnemyController>();
        var Poison = oponent.GetComponent<EnemyPoisonedController>();
        if(!Enemy.isPoisoned)
        {
            Enemy.isPoisoned = true;
            Poison.poisonWith(Elements.WATER);
            Enemy.ableToAttack = false;
            //Restore
            StartCoroutine(RestoreAttack(Enemy, Poison));
        }
    }

    private IEnumerator RestoreAttack(EnemyController Enemy, EnemyPoisonedController Poison)
    {
        yield return new WaitForSeconds(WaterDurance);
        Poison.DestroyPoison();
        Enemy.isPoisoned = false;
        Enemy.ableToAttack = true;
    }
    // ***************************************************


    public void EnhanceAttackWithPower(GameObject oponent, GameObject ownSelf)
    {
        switch (activePower)
        {
            case Elements.FIRE:
                FireEnhance(oponent);
                break;
            case Elements.LIGHTING:
                LightingEnhance(oponent);
                break;
            case Elements.NATURE:
                NatureEnhance(ownSelf);
                break;
            case Elements.WATER:
                WaterEnhance(oponent);
                break;
            default:
                break;
        }
    }

}
