using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjAntorcha : MonoBehaviour
{
    public Light Luz;
    public GameObject Fuego;
    public TextMeshPro Text;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>(true);
        Luz = GetComponentInChildren<Light>(true);
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = "Aqui puedes construir una antorcha";
            player.OnTrigger = true;
            player.Trigger = gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = "";
            player.OnTrigger = false;
            player.Trigger = null;
        }
    }

    public void interactuar()
    {
        // si en el () esta True, busca en todos lados incluyendo objetos inactivos.
        
        if (player.pedernal >= 4 && player.madera >=4)
        {
            Luz.enabled = true;
            Fuego.SetActive(true);
            player.pedernal -= 4;
            player.madera -= 4;
            Text.text = "";
            Destroy(Text.gameObject);
            Destroy(this);
            player.Trigger = null;
            player.OnTrigger = false;
        }
        else
        {
            Text.text = "No tenes los materiales suficientes";
        }
    }
}
