using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGlow : MonoBehaviour {

    private Color defaultColor = Color.white;
    private Color transparent = new Color(0f, 0f, 0f, 0f);

    private SpriteRenderer spriteRenderer;

    private float lerpProgress;

    public float lerpSpeed = 1f;
    public float lerpDamp  = 0.5f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        Color lerpColor = Color.white;
        lerpColor = Color.Lerp(transparent, defaultColor, Mathf.Abs(Mathf.Sin(Time.time * lerpSpeed)));
        spriteRenderer.color = lerpColor;
    }
}
