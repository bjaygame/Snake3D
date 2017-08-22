using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour {
    [Flags]
    private enum Direction 
    {
        Up = 1<<0,
        Down= 1<<1,
        Left = 1<<2,
        Right = 1<<3,
    }

    private List<Transform> snakeList;


    private GameObject[] goPrefabs;

    private Direction dir;
    private Vector3 moveStep;
    private WaitForSeconds delay;
    private float moveTimedelta = 0.1f;
    private Vector3 PreVec = Vector3.zero;

	void Start () {
        snakeList = new List<Transform>();

        goPrefabs = new GameObject[2];
        goPrefabs[0] = Resources.Load<GameObject>("Prefabs/body01");
        goPrefabs[1] = Resources.Load<GameObject>("Prefabs/body02");

        Transform[] trans = GetComponentsInChildren<Transform>();
        for (int i = 1; i < trans.Length; i++) {
            snakeList.Add(trans[i]);
        }

        dir = Direction.Right;
        moveStep = new Vector3(0.5f, 0, 0);   //默认向右
        delay = new WaitForSeconds(moveTimedelta);
        StartCoroutine(Move());
    }
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.W)) {
            dir = (dir == Direction.Down ? Direction.Down : Direction.Up);
        }

        else if(Input.GetKeyDown(KeyCode.S)) {
            dir = (dir == Direction.Up ? Direction.Up : Direction.Down);
        }

        else if(Input.GetKeyDown(KeyCode.A)) {
            dir = (dir == Direction.Right ? Direction.Right : Direction.Left);
        }

        else if(Input.GetKeyDown(KeyCode.D)) {
            dir = (dir == Direction.Left ? Direction.Left : Direction.Right);
        }

        SetMoveStep();
    }

    IEnumerator Move() {
        while (true)
        {
            PreVec = snakeList[0].position;
            snakeList[0].position += moveStep;
            for (int i = 1; i < snakeList.Count; i++)
            {
                Vector3 temp = snakeList[i].position;
                snakeList[i].position = PreVec;
                PreVec = temp;
            }

            yield return delay;
        }        
    }

    //设置移动步长
    private void SetMoveStep()
    {
        switch(dir)
        {
            case Direction.Up:
                moveStep = Vector3.forward * 0.5f;
                break;
            case Direction.Down:
                moveStep = Vector3.back * 0.5f;
                break;
            case Direction.Left:
                moveStep = Vector3.left * 0.5f;
                break;
            case Direction.Right:
                moveStep = Vector3.right * 0.5f;
                break;
        }          
    }

    public void EatFood(int score)
    {
        GameObject goTail = Instantiate(goPrefabs[score % 2]);
        goTail.transform.position = snakeList[snakeList.Count - 1].position;
        snakeList.Add(goTail.transform);

        goTail.transform.parent = this.transform;
    }

   
}
