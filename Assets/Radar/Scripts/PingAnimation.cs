using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float disappearTimer = 0f;
    [SerializeField] private float disappearTimerMax = 1.5f;
    [SerializeField] Color color = new Color(0, 1, 0, 0f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        disappearTimer += Time.deltaTime;

        color.a = Mathf.Lerp(disappearTimerMax, 0f, disappearTimer / disappearTimerMax);
        spriteRenderer.color = color;

        if (disappearTimer >= disappearTimerMax)
        {
            Destroy(gameObject);
        }
    }

    public void SetColor(Color color) 
    {
        this.color = color;
    }

    public void SetDisappearTimer(float disappearTimerMax) 
    {
        this.disappearTimerMax = disappearTimerMax;
        disappearTimer = 0f;
    }
}
