﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportTarget; // enviar al otro escenario->nivel
    public GameObject Player;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = teleportTarget.transform.position;
    }
}
