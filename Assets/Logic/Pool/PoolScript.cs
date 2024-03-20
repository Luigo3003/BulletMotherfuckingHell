using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    private List<GameObject> availableObjectpoolList;
    private List<GameObject> activepoolList;

    [SerializeField] private GameObject PoolPrefab;
    [SerializeField] private int StartingNumberofObjects;
    [SerializeField] private float despawnTimer;


    private void Awake()
    {
        availableObjectpoolList = new List<GameObject>();
        activepoolList = new List<GameObject>();
    }
    void Start()
    {
        CreateObject(StartingNumberofObjects);
    }

    private void CreateObject(int numberOfObjects)
    {
        GameObject TempObject;
        for (int i = 0; i < numberOfObjects; i++)
        {
            TempObject = Instantiate(PoolPrefab, Vector3.zero, Quaternion.identity, transform);
            TempObject.SetActive(false);
            availableObjectpoolList.Add(TempObject);
        }
    }

    public GameObject RequestObject()
    {
        if (availableObjectpoolList.Count != 0)
        {
            GameObject requestedObject = availableObjectpoolList[0];
            availableObjectpoolList.RemoveAt(0);
            activepoolList.Add(requestedObject);
            return requestedObject;
        }

        else
        {
            CreateObject(1);
            return RequestObject(); ;
        }
    }

    public void TurnOffObjects(GameObject objectToDespawn)
    {

        availableObjectpoolList.Add(objectToDespawn);
        activepoolList.Remove(objectToDespawn);
        objectToDespawn.SetActive(false);   
    }
}
