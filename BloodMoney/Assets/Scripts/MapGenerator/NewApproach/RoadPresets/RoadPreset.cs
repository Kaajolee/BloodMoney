using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Road preset", menuName = "New road Preset")]
public class RoadPreset : ScriptableObject
{
    public GameObject intersectionPrefab;
    public GameObject verticalPrefab;
    public GameObject horizontalPrefab;
    public GameObject roadEndPrefab;

}
