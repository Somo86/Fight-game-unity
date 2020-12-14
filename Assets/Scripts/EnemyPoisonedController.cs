using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoisonedController : MonoBehaviour
{
    public GameObject FirePoison;
    public GameObject LightPoison;
    public GameObject NaturePoison;
    public GameObject WaterPoison;
    private GameObject currentPoison;

    public void poisonWith(Elements poison)
    {
        switch (poison)
        {
            case Elements.FIRE:
                CreateEffect(FirePoison);
                break;
            case Elements.LIGHTING:
                CreateEffect(LightPoison);
                break;
            case Elements.NATURE:
                CreateEffect(NaturePoison);
                break;
            case Elements.WATER:
                CreateEffect(WaterPoison);
                break;
            default:
                break;
        }
    }

    private void CreateEffect(GameObject Poison)
    {
        currentPoison = Instantiate(Poison, transform);
    }

    public void DestroyPoison()
    {
        Destroy(currentPoison);
    }
}
