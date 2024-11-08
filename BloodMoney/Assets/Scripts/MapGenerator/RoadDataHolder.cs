using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDataHolder : MonoBehaviour
{
    public List<Transform> VisualConnectionPoints;
    public RoadType RoadType;
}
public enum RoadType
{
    MainRoad,
    ResidentialRoad,
    Gravel,
    Sand,
}