using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public InventoryScript.SwordType swordType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryScript.EquipSword(swordType);
            
            Debug.Log($"{swordType} coletado");
            Destroy(gameObject);
        }
    }
}
