using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public void Breakdown()
    {
        //play some nice animation and sound
        Destroy(gameObject);

    }
}
