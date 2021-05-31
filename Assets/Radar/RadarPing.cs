// This code was by Code Monkey: https://www.youtube.com/watch?v=pBB_YYSujrc&t=913s&ab_channel=CodeMonkey

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPing : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private float disappearTimer;
    private float disappearTimerMax;
    private Color color;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        disappearTimerMax = 1f;
        disappearTimer = 0f;
        color = GetComponent<SpriteRenderer>().color;
        
    }

    private void Update() {
        disappearTimer += Time.deltaTime;

        color.a = Mathf.Lerp(disappearTimerMax, 0f, disappearTimer / disappearTimerMax);
        spriteRenderer.color = color;

        if (disappearTimer >= disappearTimerMax) {
            Destroy(gameObject);
        }
    }

    public void SetColor(Color color) {
        this.color = color;
    }

    public void SetDisappearTimer(float disappearTimerMax) {
        this.disappearTimerMax = disappearTimerMax;
        disappearTimer = 0f;
    }

}
