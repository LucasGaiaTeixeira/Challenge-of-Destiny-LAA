using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Objects : ScriptableObject
{
    public string itemName;    // Nome do item
    public Sprite itemSprite;  // Sprite do item para a UI
    public string description; // Descrição do item (opcional)
}

