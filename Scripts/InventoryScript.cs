using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static int gems = 0;

    public enum SwordType { axe, lance, rapier, sai, sword, none }
    public static SwordType sword = SwordType.none;

    public static void EquipSword(SwordType newSword)
    {
        sword = newSword;
        Debug.Log($"Nova arma {sword}");
    }

    void Start()
    {
        gems = 10;
        sword = SwordType.none;

        Debug.Log($"Gemas = {gems}, Espada = {sword}");
    }
}
