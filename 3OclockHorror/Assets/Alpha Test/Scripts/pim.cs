using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pim : MonoBehaviour //Player Instance Manager
{
	public static pim instance; 

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject); //Is there a player? If yes, destroy me
		}
		else
		{
			instance = this;  //There isnt a player? I'm it
			DontDestroyOnLoad(gameObject);
		}
	}
}
