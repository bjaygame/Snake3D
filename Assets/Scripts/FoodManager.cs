using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour 
{
    private static FoodManager _instance;
    public static FoodManager Instance
    {
        get
        {
            return ( _instance = _instance ?? new FoodManager());
        }
    }
    
    private GameObject foodPrefab;

    void Awake()
    {
        foodPrefab = Resources.Load<GameObject>("Prefabs/Food");

        CreateFood();

        _instance = this;
    }



    public void CreateFood()
    {
        GameObject goFood = Instantiate(foodPrefab);
        goFood.transform.position = new Vector3(Random.Range(-10.5f, 10.5f), 0, Random.Range(-5f, 5f));
    }
}
