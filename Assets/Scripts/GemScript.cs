using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManagerScript;

public class GemScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManager;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (gameManager.currentState)
        {
            case GameState.YELLOWJAMS: spriteRenderer.color = Color.blue; break;
            case GameState.REDJAMS: spriteRenderer.color = Color.red; break;
            case GameState.FINALBOSS: spriteRenderer.color = Color.white; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("gem collected");

        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GemCollected();
            Destroy(gameObject);
        }
    }
}
