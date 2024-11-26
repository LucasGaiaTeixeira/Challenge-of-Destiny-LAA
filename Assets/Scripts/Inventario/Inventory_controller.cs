using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_controller : MonoBehaviour
{
    public Image[] slotImages; // Referência aos slots do inventário no Canvas
    public Objects[] slots;    // Referência aos ScriptableObjects nos slots (opcional para visualização direta)

    // Dicionário para armazenar os itens no inventário com seus nomes
    private Dictionary<string, Objects> inventoryHashTable = new Dictionary<string, Objects>();

    // Adiciona um item ao inventário
    public void AddToInventory(Objects itemData)
    {
        // Verifica se o item já existe na hash table
        if (inventoryHashTable.ContainsKey(itemData.itemName))
        {
            Debug.Log($"Item '{itemData.itemName}' já está no inventário.");
            return; // Não adiciona duplicatas
        }

        // Adiciona ao dicionário (hash table)
        inventoryHashTable.Add(itemData.itemName, itemData);

        // Reorganiza o inventário baseado no comprimento do nome
        SortInventory();

        // Atualiza a UI com os itens organizados
        UpdateInventoryUI();
    }

    // Reorganiza os itens com base no tamanho do nome
    private void SortInventory()
    {
        // Ordena o inventário com base no comprimento do nome do item
        var sortedItems = new List<Objects>(inventoryHashTable.Values);
        sortedItems.Sort((a, b) => a.itemName.Length.CompareTo(b.itemName.Length));

        // Limpa o dicionário e adiciona os itens ordenados de volta
        inventoryHashTable.Clear();
        foreach (var item in sortedItems)
        {
            inventoryHashTable.Add(item.itemName, item);
        }
    }

    // Atualiza a UI do inventário
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

    // Função de depuração para imprimir o conteúdo do inventário
    public void DebugInventory()
    {
        Debug.Log("=== Conteúdo do Inventário ===");
        foreach (var item in inventoryHashTable)
        {
            Debug.Log($"Item: {item.Key}, Nome: {item.Value.itemName}");
        }
    }

    // Verifica se um item está no inventário
    public bool HasItem(string itemName)
    {
        return inventoryHashTable.ContainsKey(itemName);
    }

    // Obtém o item pelo nome (se necessário)
    public Objects GetItem(string itemName)
    {
        if (inventoryHashTable.TryGetValue(itemName, out Objects item))
        {
            return item;
        }

        Debug.Log($"Item '{itemName}' não encontrado no inventário.");
        return null;
    }
}
