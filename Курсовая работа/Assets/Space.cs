using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour {

    /**@mainpage О программе *Данный скрипт работает с заставками:
*  1) Начало игры, выбор пользователя следующих действий  */

    void Start () {
		
	}
	
	
	void Update () {
        // Выбор игры, начало игры 
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Level 2");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) /* !< если нажат пробел, то выход */
        {
            Application.Quit();
        }
    }
}
