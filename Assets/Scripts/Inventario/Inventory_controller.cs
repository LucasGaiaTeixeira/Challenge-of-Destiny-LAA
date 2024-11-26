using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_controller : MonoBehaviour
{
    public Image[] slotImages; // Refer�ncia aos slots do invent�rio no Canvas
    public Objects[] slots;    // Refer�ncia aos ScriptableObjects nos slots (opcional para visualiza��o direta)

    // Dicion�rio para armazenar os itens no invent�rio com seus nomes
    private Dictionary<string, Objects> inventoryHashTable = new Dictionary<string, Objects>();

    // Adiciona um item ao invent�rio
    public void AddToInventory(Objects itemData)
    {
        // Verifica se o item j� existe na hash table
        if (inventoryHashTable.ContainsKey(itemData.itemName))
        {
            Debug.Log($"Item '{itemData.itemName}' j� est� no invent�rio.");
            return; // N�o adiciona duplicatas
        }

        // Adiciona ao dicion�rio (hash table)
        inventoryHashTable.Add(itemData.itemName, itemData);

        // Reorganiza o invent�rio baseado no comprimento do nome
        SortInventory();

        // Atualiza a UI com os itens organizados
        UpdateInventoryUI();
    }

    // Reorganiza os itens com base no tamanho do nome
    private void SortInventory()
    {
        // Ordena o invent�rio com base no comprimento do nome do item
        var sortedItems = new List<Objects>(inventoryHashTable.Values);
        sortedItems.Sort((a, b) => a.itemName.Length.CompareTo(b.itemName.Length));

        // Limpa o dicion�rio e adiciona os itens ordenados de volta
        inventoryHashTable.Clear();
        foreach (var item in sortedItems)
        {
            inventoryHashTable.Add(item.itemName, item);
        }
    }

    // Atualiza a UI do invent�rio
    private void UpdateInventoryUI()
    {
        // Limpa os slots da UI
        for (int i = 0; i < slotImages.Length; i++)
        {
            slotImages[i].sprite = null;
            slotImages[i].enabled = false;
        }

        // Atualiza os slots com os itens ordenados
        int index = 0;
        foreach (var item in inventoryHashTable.Values)
        {
            if (index < slotImages.Length)
            {
                slotImages[index].sprite = item.itemSprite;
                slotImages[index].enabled = true;
                index++;
            }
        }
    }

    // Fun��o de depura��o para imprimir o conte�do do invent�rio
    public void DebugInventory()
    {
        Debug.Log("=== Conte�do do Invent�rio ===");
        foreach (var item in inventoryHashTable)
        {
            Debug.Log($"Item: {item.Key}, Nome: {item.Value.itemName}");
        }
    }

    // Verifica se um item est� no invent�rio
    public bool HasItem(string itemName)
    {
        return inventoryHashTable.ContainsKey(itemName);
    }

    // Obt�m o item pelo nome (se necess�rio)
    public Objects GetItem(string itemName)
    {
        if (inventoryHashTable.TryGetValue(itemName, out Objects item))
        {
            return item;
        }

        Debug.Log($"Item '{itemName}' n�o encontrado no invent�rio.");
        return null;
    }
}
