using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory_controller : MonoBehaviour
{
    public Image[] slotImages; // Referência aos slots do inventário no Canvas
    public Objects[] slots;   // Referência aos ScriptableObjects nos slots

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object")) // Detecta objetos com a tag "Object"
        {
            Item2d item = collision.GetComponent<Item2d>();
            if (item != null) // Garante que o objeto tem o script "Item2D"
            {
                AddToInventory(item.itemData); // Adiciona ao inventário
                Destroy(collision.gameObject); // Remove o objeto do mapa
            }
        }
    }

    public void AddToInventory(Objects itemData)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null) // Encontra o primeiro slot vazio
            {
                slots[i] = itemData; // Armazena o ScriptableObject no slot
                slotImages[i].sprite = itemData.itemSprite; // Atualiza o ícone na UI
                slotImages[i].enabled = true; // Mostra o slot
                return;
            }
        }

        Debug.Log("Inventário cheio!");
    }
}