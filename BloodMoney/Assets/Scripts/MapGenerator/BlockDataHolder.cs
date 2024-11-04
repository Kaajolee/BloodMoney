using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDataHolder : MonoBehaviour
{
    [Header("Connection points")]
    public Transform TopPoint;
    public Transform BottomPoint;
    public Transform LeftPoint;
    public Transform RightPoint;
    public Transform CenterPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BlockGenerator.Instance.SetCurrentBlock(gameObject);
    }
}
public enum CurrentCornerPlayerIsIn
{
    Top,
    Bottom,
    Left,
    Right
}
