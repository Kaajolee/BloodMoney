using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    private static BlockGenerator _instance;
    public static BlockGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("BlockGenerator is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private List<GameObject> CityBlocks;

    [SerializeField]
    private GameObject currentBlock; //on what block is the player on right now

    [SerializeField]
    private CurrentCornerPlayerIsIn currentCorner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            InstantiateBlock();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentCorner = CurrentCornerPlayerIsIn.Left;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentCorner = CurrentCornerPlayerIsIn.Right;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            currentCorner = CurrentCornerPlayerIsIn.Top;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            currentCorner = CurrentCornerPlayerIsIn.Bottom;
    }


    void InstantiateBlock()
    {
        GameObject blockToCreate = GetBlock(currentBlock);
        GameObject instantiatedBlock = Instantiate(blockToCreate);

        //prijungimo poziciju data
        BlockDataHolder currentData = currentBlock.GetComponent<BlockDataHolder>();
        BlockDataHolder newData = instantiatedBlock.GetComponent<BlockDataHolder>();

        DataHolder instantiatedConnectionDataHolder = instantiatedBlock.AddComponent<DataHolder>();
        instantiatedConnectionDataHolder.DataObject = ScriptableObject.CreateInstance<Block>();


        //gauti kampu boolean'us ar prijungta kas ar ne
        Block currentBlockConnectionData = (Block)currentBlock.GetComponent<DataHolder>().DataObject;
        Block instantiatedConnectionData = (Block)instantiatedConnectionDataHolder.DataObject;



        Vector2 placeTo = CalculatePosition(currentData, newData, instantiatedBlock.transform.position, currentCorner);

        SetBooleans(currentCorner, currentBlockConnectionData, instantiatedConnectionData);

        instantiatedBlock.transform.position = placeTo;
    }



    Vector2 CalculatePosition(BlockDataHolder currentBlockData, BlockDataHolder newBlockData, Vector2 initialPosition, CurrentCornerPlayerIsIn currentCorner)
    {
        //pradinaii variables
        Vector2 targetConnectionPoint = Vector2.zero;
        Vector2 newBlockConnectionPoint = Vector2.zero;

        //switchas nustatyti puses
        switch (currentCorner)
        {
            case CurrentCornerPlayerIsIn.Top:
                targetConnectionPoint = currentBlockData.TopPoint.position;
                newBlockConnectionPoint = newBlockData.BottomPoint.position;
                break;

            case CurrentCornerPlayerIsIn.Bottom:
                targetConnectionPoint = currentBlockData.BottomPoint.position;
                newBlockConnectionPoint = newBlockData.TopPoint.position;
                break;

            case CurrentCornerPlayerIsIn.Left:
                targetConnectionPoint = currentBlockData.LeftPoint.position;
                newBlockConnectionPoint = newBlockData.RightPoint.position;
                break;

            case CurrentCornerPlayerIsIn.Right:
                targetConnectionPoint = currentBlockData.RightPoint.position;
                newBlockConnectionPoint = newBlockData.LeftPoint.position;
                break;
        }

        // sulygina
        return initialPosition + (targetConnectionPoint - newBlockConnectionPoint);
    }

    void SetBooleans(CurrentCornerPlayerIsIn currentCorner, Block currentBlockConnectionData, Block instantiatedBlockConnectionData)
    {
        switch (currentCorner) 
        {
            case CurrentCornerPlayerIsIn.Top:
                currentBlockConnectionData.isTopConnected = true;
                instantiatedBlockConnectionData.isBottomConnected = true;
                break;

            case CurrentCornerPlayerIsIn.Bottom:
                currentBlockConnectionData.isBottomConnected= true;
                instantiatedBlockConnectionData.isTopConnected= true;
                break;

            case CurrentCornerPlayerIsIn.Left:
                currentBlockConnectionData.isLeftConnected = true;
                instantiatedBlockConnectionData.isRightConnected = true;
                break;

            case CurrentCornerPlayerIsIn.Right:
                currentBlockConnectionData.isRightConnected = true;
                instantiatedBlockConnectionData.isLeftConnected = true;
                break;
        }
    }

    GameObject GetBlock(GameObject currentBlock) 
    {
        GameObject block = GetRandomBlock();

        if(currentBlock == block)
        {
            block = GetRandomBlock();
            return block;
        }
        else
            return block;
    }


    GameObject GetRandomBlock()
    {
        GameObject block = CityBlocks[Random.Range(0, CityBlocks.Count)];

        return block;
    }


    public void SetCurrentBlock(GameObject block)
    {
        currentBlock = block;
    }



}
