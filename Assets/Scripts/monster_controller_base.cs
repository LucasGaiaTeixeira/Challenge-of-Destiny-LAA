using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.AssetImporters;
using UnityEngine;

public class monster_controller_base : MonoBehaviour
{
    public float move_bamboo = 3.5f;
    private Vector2 bamboo_direction;
    private Rigidbody2D bamboo_rig;

    private Deteccao_player detect_player;

    private void Start()
    {
        bamboo_rig = GetComponent<Rigidbody2D>();
        detect_player = GetComponentInChildren<Deteccao_player>();

    }

    private void Update()
    {
        bamboo_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (detect_player.detectobj.Count > 0) 
        {
            bamboo_direction = (detect_player.detectobj[0].transform.position - transform.position).normalized;
            bamboo_rig.MovePosition(bamboo_rig.position + bamboo_direction * move_bamboo * Time.fixedDeltaTime);
        }
    }
}
