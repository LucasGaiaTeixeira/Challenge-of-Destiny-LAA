using UnityEngine;

public class GemScript : MonoBehaviour
{
    [SerializeField] private GameManagerScript gameManager;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (gameManager.currentState)
        {
            case GameManagerScript.GameState.YELLOWJAMS:
                spriteRenderer.color = Color.blue;
                break;
            case GameManagerScript.GameState.REDJAMS:
                spriteRenderer.color = Color.red;
                break;
            case GameManagerScript.GameState.FINALBOSS:
                spriteRenderer.color = Color.white;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("+1 Gema");

            gameManager.GemCollected();

            Destroy(gameObject);
        }
    }
}
