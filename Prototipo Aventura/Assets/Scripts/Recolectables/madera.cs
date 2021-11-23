using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class madera : MonoBehaviour
{
    private GameObject DaMadera;
    public TextMeshPro Text;
    private Player player;
    public int cantDada = 10;

    private void Start()
    {
        player = FindObjectOfType<Player>(true);
        DaMadera = this.gameObject;
    }

    void Update()
    {
        Text.transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = "Aqui puedes recolectar madera";
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

    void interactuar()
    {
        player.madera += cantDada;
        Text.text = "";
        Destroy(Text.gameObject);
        Destroy(this);
        Destroy(DaMadera);
        player.Trigger = null;
        player.OnTrigger = false;
    }

}
