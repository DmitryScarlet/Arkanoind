using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

    private bool ballIsActive;
    private Vector3 ballPoisition;
    private Vector2 ballForce;
    public Rigidbody2D RB;
    public GameObject playerObject;

    /**@mainpage О программе *Данный скрипт работает с мячом:
* 1) Создание силы мяча 
  2) Задание физики мяча
  3) Вызов метода забрать жизнь, если мяч ушел за пределы*/

    //Для инициализации переменных 
    void Start () {

        /**@page pagereq Структура программы 
  *@section d Описание переменных 
  *@note Vector2 ballForce - сила мяча 
  *@note bool ballIsActive - активность, пассивность мяча
  *@note Vector3 ballPoisition - позиция мяча
  @code ///*/

        ballForce = new Vector2(180.0f, 470.0f);//создание силы
        ballIsActive = false;// нет движения
        ballPoisition = transform.position;// положение мяча = положению платформы, запоминаем положение
        RB = GetComponent<Rigidbody2D>();// физика мяча 
	}

    // Обновление кадров игры
	void Update () {

        if (Input.GetButtonDown("Jump") == true || (Input.GetMouseButtonDown(0)))//проверка нажатия пробела или мыши 
        {
            if (!ballIsActive)// проверка состояния
            {
                RB.velocity = Vector2.zero;// сброс сил
                RB.AddForce(ballForce);//применение силы
                ballIsActive = !ballIsActive;// движение, задание активного состояния
            }

            

        }

        if (!ballIsActive && playerObject != null)
        {
            ballPoisition.x = playerObject.transform.position.x;// новая позиция
            transform.position = ballPoisition;// установление позиции
        }

        if (ballIsActive && transform.position.y < -6)//проверка пределов, проверка падение шара
        {
            ballIsActive = !ballIsActive;
            ballPoisition.x = playerObject.transform.position.x;
            ballPoisition.y = -4.3f;
            transform.position = ballPoisition;

            playerObject.SendMessage("TakeLife");//если выполняется, забрать жизнь, вызвав метод

        }

    }
   
}
