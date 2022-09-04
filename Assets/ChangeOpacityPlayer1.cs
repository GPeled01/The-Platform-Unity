using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
public class ChangeOpacityPlayer1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.controlEnabled)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}
