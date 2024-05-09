using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<UnitPool> units = new();

    public Dictionary<string, GameObject> unitDic = new();

    private void Awake()
    {
        MakeDictionary();
    }

    private void Start()
    {
        Spawn();
    }

    private void MakeDictionary()
    {
        for(int i = 0; i < units.Count; i++)
        {
            unitDic.Add(units[i].key, units[i].unit);
        }
    }

    private void Spawn()
    {
        var ob = Instantiate(unitDic[GameManager.instance.label]);
        ob.transform.position = Vector3.zero;
    }
}
