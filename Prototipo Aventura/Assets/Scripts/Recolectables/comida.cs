using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class comida : MonoBehaviour
{
    private GameObject DaComida;
    public TextMeshPro Text;
    private Player player;
    public int cantDada = 3;

    private void Start()
    {
        player = FindObjectOfType<Player>(true);
        DaComida = this.gameObject;
    }

    void Update()
    {
        Text.transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.text = "Aqui puedes recolectar Comida";
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
        player.comida += cantDada;
        Text.text = "";
        Destroy(Text.gameObject);
        Destroy(this);
        Destroy(DaComida);
        player.Trigger = null;
        player.OnTrigger = false;
    }
}
