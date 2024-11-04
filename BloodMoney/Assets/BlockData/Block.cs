using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New block", menuName = "Block/Create new block data")]
public class Block : ScriptableObject
{
    public bool isTopConnected;
    public bool isBottomConnected;
    public bool isLeftConnected;
    public bool isRightConnected;
}
