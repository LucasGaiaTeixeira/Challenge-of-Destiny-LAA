using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    [SerializeField] public float speed = 7f;
    private Rigidbody2D rig;
    private Vector2 direcao;

    public bool atack = false;

    public Vector2 direction
    {
        get { return direcao; }
        set { direcao = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direcao = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        onAtack(); // Verifica se o jogador est� atacando
    }

    private void FixedUpdate()
    {
        // S� permite movimento se n�o estiver atacando
        if (!atack)
        {
            rig.MovePosition(rig.position + direcao * speed * Time.fixedDeltaTime); // Movimenta��o na f�sica do jogador
        }
    }

    void onAtack()
    {
        // Ataque para cima
        if (Input.GetKey(KeyCode.X))
        {
            atack = true;
            direcao = Vector2.up; // Dire��o para cima
        }
        // Ataque para baixo
        else if (Input.GetKey(KeyCode.C))
        {
            atack = true;
            direcao = Vector2.down; // Dire��o para baixo
        }
        // Ataque para esquerda
        else if (Input.GetKey(KeyCode.Z))
        {
            atack = true;
            direcao = Vector2.left; // Dire��o para esquerda
        }
        // Ataque para direita
        else if (Input.GetKey(KeyCode.V))
        {
            atack = true;
            direcao = Vector2.right; // Dire��o para direita
        }
        else
        {
            atack = false; // Nenhum ataque
        }
    }
}
