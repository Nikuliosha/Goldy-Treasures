using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GoldyMovement movement;

    public Sprite idle;
    public Sprite jump;
    public Animation run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<GoldyMovement>();
    }

    private void onEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = movement.running;
        if (movement.isJumping)
        {
           spriteRenderer.sprite = jump;
        }
        else if (!movement.running)
        {
            spriteRenderer.sprite = idle;
        }
        
    }
}
