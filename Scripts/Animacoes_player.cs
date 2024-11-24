using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes_player : MonoBehaviour
{
    private PlayerScript player;
    private Animator anime;

    void Start()
    {
        player = GetComponent<PlayerScript>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = player.direction;

        // Verifica se o jogador está atacando
        if (player.atack)
        {
            // Determina a animação de ataque com base na direção
            if (direction == Vector2.up)
            {
                anime.SetInteger("transition", 8); // Ataque para cima
            }
            else if (direction == Vector2.down)
            {
                anime.SetInteger("transition", 5); // Ataque para baixo
            }
            else if (direction == Vector2.left)
            {
                anime.SetInteger("transition", 6); // Ataque para esquerda
            }
            else if (direction == Vector2.right)
            {
                anime.SetInteger("transition", 7); // Ataque para direita
            }
        }
        else // Movimento normal ou idle
        {
            // Se o jogador está se movendo, ativa a animação de movimento
            if (direction.sqrMagnitude > 0)
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) // Movimento horizontal
                {
                    if (direction.x > 0)
                    {
                        anime.SetInteger("transition", 1); // Movimento para direita
                    }
                    else
                    {
                        anime.SetInteger("transition", 4); // Movimento para esquerda
                    }
                }
                else // Movimento vertical
                {
                    anime.SetInteger("transition", direction.y > 0 ? 2 : 3); // Cima ou baixo
                }
            }
            else
            {
                anime.SetInteger("transition", 0); // Idle
            }
        }
    }
}
