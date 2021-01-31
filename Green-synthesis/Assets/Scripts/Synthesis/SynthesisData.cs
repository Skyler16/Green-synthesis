using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SynthesisData : ScriptableObject
{
    [SerializeField]
    GameObject[] SynObjectPrefabs;
    public int[] scores;
    public int[] levelIndexRange;
    public int[] levelWeights = { 32, 16, 8, 4, 2 };  

public int SynthesisObjectSize
    {
        get
        {
            return SynObjectPrefabs.Length;
        }
    }

    public GameObject GetSynthesisGameObject(int id)
    {
        return SynObjectPrefabs[id];
    }
}
