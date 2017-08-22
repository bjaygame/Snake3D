using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour 
{
    private SnakeMove snake;

    private void Start()
    {
        snake = GameObject.Find("Snake").GetComponent<SnakeMove>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Head")
        {
            Destroy(gameObject);
            FoodManager.Instance.CreateFood();

            SceneManager.Instance.Score++;
            snake.EatFood(SceneManager.Instance.Score);
        }
    }
}
