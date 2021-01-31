using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    //[SerializeField]
    //int objectSize = 5;

    [SerializeField]
    float timeInterval = 3;
    [SerializeField]
    float timePass = 0;

    public float moveSpeed = 2;

    [SerializeField]
    Transform pivotStart, pivotEnd;

    //Queue<GameObject> objectList;

    SynthesisData synData;

    public static ResourcePanel Get
    {
        get
        {
            return instance;
        }
    }
    static ResourcePanel instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        synData = Resources.Load<SynthesisData>("Object List");
    }

    // Start is called before the first frame update
    void Start()
    {
        timePass = timeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePass >= timeInterval)
        {
            timePass = 0;
            SpawnObject();
        }
        timePass += Time.deltaTime;
    }

    GameObject GetRandomObject()
    {
        int id = RandomIndex.GetRandomIndex(synData.levelIndexRange, synData.levelWeights);
        GameObject o = synData.GetSynthesisGameObject(id);
        return Instantiate(o);
    }

    void SpawnObject()
    {
        GameObject o = GetRandomObject();
        o.transform.SetParent(transform);
        o.transform.localPosition = pivotStart.localPosition + new Vector3(0, 0, 0.3f);
        o.tag = "Resource";
        o.AddComponent<ResoucePanelObject>();
        o.GetComponent<ResoucePanelObject>().objId = o.GetComponent<SynthesisObject>().id;

    }
}
