using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private PlayerScript player; 
    [SerializeField] private GateScript gate; 
    [SerializeField] private int gemCount = 0; 
    public enum GameState
    {
        YELLOWJAMS,
        REDJAMS,
        FINALBOSS,
        END,
        GAMEOVER
    }

    public GameState currentState;

    private void Start()
    {
        currentState = GameState.YELLOWJAMS;
    }

    public void GemCollected()
    {
        gemCount++;
        Debug.Log("Você tem: " + gemCount + " gemas");

        switch (gemCount)
        {
            case 5:
                currentState = GameState.REDJAMS;
                gate.Breakdown();
                Debug.Log("A passagem para a outra ilha foi aberta");
                break;

            case 10:
                currentState = GameState.FINALBOSS;
                Debug.Log("A porta que leva para o ultimo chefe foi aberta");
                break;

            case 11:
                currentState = GameState.END;
                Debug.Log("Fim");
                break;
        }
    }
    public void SwordCollected(InventoryScript.SwordType swordType)
    {
        InventoryScript.EquipSword(swordType);
        Debug.Log($"Espada coletada e equipada: {swordType}");
    }

}
