using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsPoint;
    [SerializeField] private Transform parentListObjPoint;
    [SerializeField] private List<Road> listRoad;
    private bool canCheck = true;
    public int roadIndex = 0;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObjPoint)
        {
            if(tr.gameObject.activeSelf)
                gameObjectsPoint.Add(tr.gameObject);
        }
        StartLevel();
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        if (canCheck)
        {
            /*if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }*/
        }
    }

    public void NextRoad()
    {
        GameManager.Instance.canDrag = false;
        roadIndex++;
        if (roadIndex >= listRoad.Count)
        {
            GameManager.Instance.CheckLevelUp();
        }
        else
        {
            listRoad[roadIndex].MoveToSpawn();
        }
    }

    public Road GetCurrentRoad()
    {
        return listRoad[roadIndex];
    }

    public void StartLevel()
    {
        roadIndex = 0;
    }
}