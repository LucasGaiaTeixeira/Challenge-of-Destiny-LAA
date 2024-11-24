using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deteccao_player : MonoBehaviour
{
    public string targetDetectionTag = "Player";
    public List<Collider2D> detectobj = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == targetDetectionTag)
        {
            detectobj.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetDetectionTag)
        {
            detectobj.Remove(collision);
        }
    }
}
