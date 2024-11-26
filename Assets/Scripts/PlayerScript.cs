using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    [SerializeField] public float speed = 7f;
    private Rigidbody2D rig;
    private Vector2 direcao;

    public bool atack = false;

    private Inventory_controller inventoryController; // Referência ao InventoryController no mesmo GameObject

    public Vector2 direction
    {
        get { return direcao; }
        set { direcao = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        inventoryController = GetComponent<Inventory_controller>(); // Acessa o InventoryController no mesmo GameObject
    }

    private void Update()
    {
        direcao = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        onAtack(); // Verifica se o jogador está atacando
    }

    private void FixedUpdate()
    {
        // Só permite movimento se não estiver atacando
        if (!atack)
        {
            rig.MovePosition(rig.position + direcao * speed * Time.fixedDeltaTime); // Movimentação na física do jogador
        }
    }

    void onAtack()
    {
        // Ataque para cima
        if (Input.GetKey(KeyCode.X))
        {
            atack = true;
            direcao = Vector2.up; // Direção para cima
        }
        // Ataque para baixo
        else if (Input.GetKey(KeyCode.C))
        {
            atack = true;
            direcao = Vector2.down; // Direção para baixo
        }
        // Ataque para esquerda
        else if (Input.GetKey(KeyCode.Z))
        {
            atack = true;
            direcao = Vector2.left; // Direção para esquerda
        }
        // Ataque para direita
        else if (Input.GetKey(KeyCode.V))
        {
            atack = true;
            direcao = Vector2.right; // Direção para direita
        }
        else
        {
            atack = false; // Nenhum ataque
        }
    }

    // Detecta colisões com objetos coletáveis
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto tem a tag "Object"
        if (collision.CompareTag("Object"))
        {
            Debug.Log($"Colidiu com: {collision.gameObject.name}");

            // Tenta pegar o script do item no objeto
            Item2d item = collision.GetComponent<Item2d>();
            if (item != null)
            {
                // Adiciona o item ao inventário
                inventoryController.AddToInventory(item.itemData);

                // Destrói o objeto coletado
                Destroy(collision.gameObject);

                Debug.Log($"Item {item.itemData.itemName} coletado!");
            }
        }
    }
}
