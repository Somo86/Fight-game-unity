using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements
{
    NONE,
    FIRE,
    LIGHTING,
    NATURE,
    WATER,
}
public class ElementsPowerController : MonoBehaviour
{
    public Elements ElementPower = Elements.NONE;
    public GameObject FireEffect;
    public GameObject LightEffect;
    public GameObject WaterEffect;
    public GameObject NatureEffect;

    private Elements currentElement;
    private GameObject activeEffect;

    void Awake()
    {
        currentElement = ElementPower;
    }
    void Start()
    {
        InstantiateEffect(currentElement);
    }

    private void InstantiateEffect(Elements element)
    {
        switch (element)
        {
            case Elements.FIRE:
                CreateEffect(FireEffect);
                break;
            case Elements.LIGHTING:
                CreateEffect(LightEffect);
                break;
            case Elements.NATURE:
                CreateEffect(NatureEffect);
                break;
            case Elements.WATER:
                CreateEffect(WaterEffect);
                break;
            default:
                break;
        }
    }

    private void CreateEffect(GameObject Effect)
    {
        activeEffect = Instantiate(Effect, transform);
    }

    private void ChangeEffect(Elements element)
    {
        currentElement = element;
        DestroyActiveEffect();
        InstantiateEffect(element);
    }

    public void DestroyActiveEffect()
    {
        Destroy(activeEffect);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ElementsLayer = LayerMask.NameToLayer("ElementPower");
        if (collision.gameObject.layer == ElementsLayer)
        {
            var powerName = collision.gameObject.tag;
            if (powerName == "Lighting_power")
                ChangeEffect(Elements.LIGHTING);
            if (powerName == "Water_power")
                ChangeEffect(Elements.WATER);
            if (powerName == "Nature_power")
                ChangeEffect(Elements.NATURE);
            if (powerName == "Fire_power")
                ChangeEffect(Elements.FIRE);
        }

    }
}
