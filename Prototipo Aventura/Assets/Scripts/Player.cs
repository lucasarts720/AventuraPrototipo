using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    #region Variables
    bool alive = true;
    public bool OnTrigger = false;
    public GameObject Trigger;

    #region Ticks
    public float health, hunger, thirst, sleep;
    public float healthTick, hungerTick, thirstTick, sleepTick;
    public float healthMax, hungerMax, thirstMax, sleepMax;
    public float hpRegenHunger, hpRegenThirst;
    public Slider healthBar;
    public Slider hungerBar;
    public Slider thirstBar;
    public Slider sleepBar;
    #endregion

    #region inventario
    public int pedernal, madera, piedra, comida, agua;
    public TextMeshProUGUI tPedernal, tMadera, tPiedra, tComida, tAgua;
    public GameObject Panel;
    #endregion
    

    #endregion

    private void Start()
    {
        #region Ticks
        healthBar.maxValue = healthMax;
        hungerBar.maxValue = hungerMax;
        thirstBar.maxValue = thirstMax;
        sleepBar.maxValue = sleepMax;
        #endregion
    }

    void Update()
    {
        #region Bars
        if (health < healthMax && hunger > hpRegenHunger && thirst > hpRegenThirst) health += Time.deltaTime / healthTick;
        if (hunger > 0) hunger -= Time.deltaTime / hungerTick;
        if (thirst > 0) thirst -= Time.deltaTime / thirstTick;
        if (sleep > 0) sleep -= Time.deltaTime / sleepTick;

        healthBar.value = health;
        hungerBar.value = hunger;
        thirstBar.value = thirst;
        sleepBar.value = sleep;
        #endregion

        #region Actions
        if (!alive)
        {
            Die();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E) && OnTrigger)
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Comer();
        }
        // Mostrar Inventario
        Panel.SetActive(Input.GetKey(KeyCode.Tab));

        #endregion

        #region Inventario
        tPedernal.text = "Pedernal: " + pedernal.ToString();
        tMadera.text = "Madera: " + madera.ToString();
        tPiedra.text = "Piedra: " + piedra.ToString();
        tComida.text = "Comida: " + comida.ToString();
        tAgua.text = "Agua: " + agua.ToString();
        #endregion
    }

    #region Functions
    void Shoot()
    {

    }
    void Interact()
    {
        Trigger.SendMessage("interactuar");
    }
    void Comer()
    {
        hunger += 50;
        comida -= 1;
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScene");
    }
    #endregion

}