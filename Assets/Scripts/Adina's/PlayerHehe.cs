using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHehe : MonoBehaviour
{
    public float health;
    public float lerpTimer; // animate the health bars 
    public float maxHealth = 10f;
    public float chipSpeed = 2f; // how quickly the delayed bar takes to catch up to the default/ original one 

    public Image frontHealthBar;
    public Image backHealthBar;

    public TextMeshProUGUI txtNumber;
    public int number = 0;

    public bool col;

    //public TextMeshProUGUI healthText;

    void Start()
    {
        health = 0;
    }

    void Update()
    {
        txtNumber.text = ("Kill virus ") + number.ToString() + ("/ 3");
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (col == true) // THE CONDITION HERE IS "THE TYPE DOESN'T MATCH", IT WILL LOWER THE BAR, BUT I DIDN'T CODE THAT, SO THE CONDITION CAN BE FOUND IN ONE OF THE OTHER SCRIPTS WE HAVE IN GAME
        //if (Input.GetKeyDown(KeyCode.S))
        {
            NoMatch(1);
        }
        col = false;
    }

    public void UpdateHealthUI()
    {
        //Debug.Log(health);

        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth; // local variable for health; decimal fraction of our max health

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }


        // healthText.text = Mathf.Round(health) + "/" + Mathf.Round(maxHealth);
    }

    public void NoMatch(float match)
    {
        health -= match;
        lerpTimer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Minus")
        {
            Debug.Log("touch me!");
            col = true;
        }
    }

    //THIS IS FOR RESTORING HEALTH, MIGHT BE USEFUL LATER IF WE DECIDE TO IMPLEMENT MORE MECHANICS 
    public void RestoreHealth(float healAmount)
    {
        health += 33f;
        lerpTimer = 0f;
    }

    public void Increase()
    {
        number++;
        health += 3.3f;
        lerpTimer = 0f;
    }

    public void Decrease()
    {
        //number--;
        health -= 3.3f;
        lerpTimer = 0f;
    }
}
