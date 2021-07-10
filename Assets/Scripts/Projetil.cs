﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public float Velocidade = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider objetoColisao)
    {
        if (objetoColisao.tag == "Inimigo")
        {
            Destroy(objetoColisao.gameObject);
        }

        Destroy(gameObject);
    }
}