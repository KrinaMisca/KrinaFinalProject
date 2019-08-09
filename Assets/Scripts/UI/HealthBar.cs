﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public int health;
	public int nbHearts;

	//put this on UILinks
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

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
	}
}
