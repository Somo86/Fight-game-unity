using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBarLifeController : MonoBehaviour
{
    public GameObject BarLife;
    private RectTransform rt;

    private HealthController HeroHealth;
    private float initialWidth;
    private float initialHeight;
    void Awake()
    {
        rt = BarLife.GetComponent<RectTransform>();
        HeroHealth = gameObject.GetComponent<HealthController>();
        initialWidth = rt.sizeDelta.x * rt.localScale.x;
        initialHeight = rt.sizeDelta.y * rt.localScale.y;
    }

    private void Start()
    {
        initializeBar();
    }

    private void initializeBar()
    {
        updateBarLength(HeroHealth.currentLife);
    }
    public void updateBarLength(float currentLife)
    {
        var width = initialWidth * currentLife / HeroHealth.maxLife;
        rt.sizeDelta = new Vector2(width, initialHeight);
    }
}
