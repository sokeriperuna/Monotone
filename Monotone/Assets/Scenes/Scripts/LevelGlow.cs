using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGlow : MonoBehaviour {

    private Color defaultColor = Color.white;
    private Color transparent = new Color(0f, 0f, 0f, 0f);

    private Color lastColor;
    private Color nextColor;

    private SpriteRenderer spriteRenderer;

    private float lerpProgress;

    public float lerpSpeed = 1f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        lastColor = defaultColor;
        nextColor = transparent;
    }

    void Update()
    {
        lerpProgress += Time.deltaTime * lerpSpeed;

        Color lerpColor = Color.white;

        if (lerpProgress >= 1f)
        {
            lerpProgress = 0f;
            if (lastColor == transparent)
            {
                lastColor = defaultColor;
                nextColor = transparent;
            }
            else
            {
                lastColor = transparent;
                nextColor = defaultColor;
            }
        }

        if(lerpProgress < 1f)
            lerpColor = Color.Lerp(lastColor, nextColor, lerpProgress);

        spriteRenderer.color = lerpColor;
    }
}
