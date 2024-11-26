using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inteface_controller : MonoBehaviour
{
    public GameObject inventoryPanel;

    private bool invActive; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invActive =! invActive;
            inventoryPanel.SetActive(invActive);
        }
        if (invActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
