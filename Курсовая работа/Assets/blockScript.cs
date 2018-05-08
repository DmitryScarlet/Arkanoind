using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour {
    public int Hits;
    public int points;
    private int numberofHits;

    /**@mainpage О программе *Данный скрипт работает с блоками:
* 1) Имеются блоки, разрушаемые разными количествами ударов. 
(1) один удар - нанести ущерб.
(2) второй удар - нанести ущерб.
(3) третий удар - уничтожить.*/

    
    void Start () {

        /**@page pagereq Структура программы 
	*@section d Описание переменных 
    *@note int Hits - количество ударов, равное уничтожению = 3
    *@note int points - количество очков за уничтожение блоков, изначально = 0
	*@note int numberofHits - количество ударов, изначально = 0
	*@note gameObject.GetComponent<SpriteRenderer>().sprite - картинка блока
	@code ///*/

        numberofHits = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Black", typeof(Sprite));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Element 0")   /* !< Если произошло столкновение */
        {
            numberofHits++;   /* !< Увеличь количество ударов */

            if (numberofHits == 1)   /* !< Если ударов = 1, то ставь картинку с ударом */
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Crack", typeof(Sprite));
            }

            if (numberofHits == 2) /* !< Если ударов 2, то ставь картинку с двойным ударом */
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Destroyed", typeof(Sprite));
            }


            if (numberofHits == Hits) /* !< Если ударов = количеству ударов разрушения, 
                                                       то уничтожай и прибавляй баллы */
            {
               GameObject Fight = GameObject.FindGameObjectsWithTag("Player")[0];
                Fight.SendMessage("addPoints", points);
                Destroy(this.gameObject);
                
 
            }
        }
    }

    void Update () {
		
	}
}
