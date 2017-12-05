﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBreak : MonoBehaviour {
    public Transform Canavas;

    void Start()
    {
        Canavas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Canavas.gameObject.activeInHierarchy == false)
            {
                Canavas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Canavas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }

        }
	}
    
}
