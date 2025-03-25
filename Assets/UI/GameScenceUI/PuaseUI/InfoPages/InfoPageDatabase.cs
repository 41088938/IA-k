using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;
using Malee.List;

[CreateAssetMenu()]//able to create database list
public class InfoPageDatabase : ScriptableObject//able to create database list
{
    [Reorderable]
    public InfoPageArray gamePlayinfo;//able to create database list

    [System.Serializable]
    public class InfoPageArray : ReorderableArray<InfoPages> { }
}
