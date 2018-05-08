using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

    public float playerVelocity;
    private Vector3 playerPoistion;
    public float boundary;
    private int playerLives;
    private int playerPoints;
    public GameObject lifeObject;

    /**@mainpage О программе *Данный скрипт работает с основой игры:
* 1) Имеются жизни, которые отнимаюся, если мяч падает. 
  2) Имеется начальная позиция платформа, которая обновляется, если потерена жизнь
  3) Имеются очки за разбитые блоки, изначально очков = 0, максимально, что означает победу = 130 */

    // Инициализация переменных 
    void Start () {

        /**@page pagereq Структура программы 
  *@section d Описание переменных 
  *@note int playerLives - жизни игрока, изначально = 3
  *@note int playerPoints - очки игрока, изначально = 0
  *@note Vector3 playerPoistion - изначальная позиция платформы
  *@note float boundary - границы игровой зоны
  @code ///*/


        playerPoistion = gameObject.transform.position;//начальная позиция 
        playerLives = 3; //сколько возможностей, чтобы мяч упал
        playerPoints = 0; //Изначально имеется 0 очков 
        Cursor.visible = false;
        
    }
    void addPoints(int points)//накапливание очков
    {
        playerPoints += points;
    }

    void OnGUI()//показ очков в интерфейсе
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(15.0f, 3.0f, 900.0f, 900.0f), " " + playerPoints);
    }
    
    void TakeLife()//потеря очнов жизней
    {
        playerLives--;
        if (playerLives == 2)//если мяч упал 1 раз, то забери жизнь
        {
            GameObject Killer = GameObject.FindGameObjectsWithTag("Element 1")[0];
            Killer.SendMessage("KILL");
        }
        if (playerLives == 1)//если мяч упал 2 раза, то забери вторую жизнь
        {
            GameObject Killer = GameObject.FindGameObjectsWithTag("Finish")[0];
            Killer.SendMessage("KILL");
        }
        if (playerLives == 0)//если мяч упал 3 раза, то ставь заставку о проигрыше
        {
            Application.LoadLevel("LOSE");
        }

        
    }

    

    void Update ()
    {
        playerPoistion.x += Input.GetAxis("Mouse X") * playerVelocity;//горизонтальное с помощью мыши
        playerPoistion.x += Input.GetAxis("Horizontal") * playerVelocity;//горизонтальное движение

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("Level 2");//перезапуск
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();/* !<выход из игры*/
        }

        transform.position = playerPoistion;/* !< обновление позиции платформы*/

        if (playerPoistion.x < -boundary)/* !<выход за границы*/
        {
            playerPoistion.x = -boundary;   
        }
        if (playerPoistion.x > boundary)/* !<выход за границы*/
        {
            playerPoistion.x = boundary;
        }

        
        transform.position = playerPoistion;/* !<обновление позиции платформы*/

        if (playerPoints == 130)/* !<если все разбиты*/
        {
            Application.LoadLevel("WIN");/* !<окно победителя*/
        }

    }
 
}
