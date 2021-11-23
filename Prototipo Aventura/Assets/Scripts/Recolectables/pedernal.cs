using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pedernal : MonoBehaviour
{
    private GameObject DaPedernal;
    public TextMeshPro Text;
    private Player player;
    public int cantDada = 5;

    private void Start()
    {
        player = FindObjectOfType<Player>(true);
        DaPedernal = this.gameObject;
    }

    void Update()
    {
        Text.transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = "Aqui puedes recolectar pedernal";
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
        player.pedernal += cantDada;
        Text.text = "";
        Destroy(Text.gameObject);
        Destroy(this);
        Destroy(DaPedernal);
        player.Trigger = null;
        player.OnTrigger = false;
    }

}