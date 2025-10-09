using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{ 
	public GameObject gameOverScreen;
	public GameObject Player;
	
	public void Start()
	{
		Health.OnPlayerDeath += gameOverScreen;
	}
}
