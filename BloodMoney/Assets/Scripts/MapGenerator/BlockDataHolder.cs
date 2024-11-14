using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDataHolder : MonoBehaviour
{
    [Header("Connection points")]
    public Transform NorthPoint;
    public Transform SouthPoint;
    public Transform WestPoint;
    public Transform EastPoint;
    public Transform CenterPoint;
    [Space]
    public TileType BlockType;
}
public enum CurrentCornerPlayerIsIn
{
    Top,
    Bottom,
    Left,
    Right
}
