using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int health = 3;
    //public int nbHearts;

    //put this on UILinks
    public Image[] hearts;
    //public Sprite fullHeart;
    //public Sprite emptyHeart;
    /*
    private void Update()
    {
        //so it dosent go over the max container of hearth
        if (health > nbHearts)
        {
            health = nbHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < nbHearts)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }*/

    //temporary damage function
    public void TakeDamage(int dmg) {
        health -= dmg;
        if(health >= 0)
            hearts[health].gameObject.SetActive(false);
    }
}
