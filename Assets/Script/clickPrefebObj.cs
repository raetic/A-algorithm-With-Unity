using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPrefebObj : MonoBehaviour
{
    SpriteRenderer spr;
    public Color[] colors;
    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = colors[Random.Range(0, colors.Length)];
    }
    private void Update()
    {
        Color color = spr.color;
            color.a = Mathf.Lerp(spr.color.a, 0, Time.deltaTime * 5);
        spr.color = color;
        if (spr.color.a <= 0.01f) Destroy(gameObject);
    }
}
