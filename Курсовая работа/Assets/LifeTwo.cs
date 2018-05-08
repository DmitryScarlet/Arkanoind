using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTwo : MonoBehaviour {
    public GameObject Heart;

    /**@mainpage О программе *Данный скрипт работает с разрушениями блока:
*  1)  Убийство и разрушение блока */

    void Start () {
		
	}
	
	
	void KILL ()
    {
        // убить блок
            Destroy(this.gameObject);
      
    }
 
}
