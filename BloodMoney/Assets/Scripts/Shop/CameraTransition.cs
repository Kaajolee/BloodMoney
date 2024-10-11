using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private Transform[] CameraPositions;
    int index;
    public float transitionTime;

    [SerializeField]
    private ShopDataController shopDataController;
    void Start()
    {
        index = 0;
        MoveCameraTo(CameraPositions[0]);
    }
    public void MoveCameraTo(Transform whereToMove)
    {
        StartCoroutine(Transition(whereToMove.position, whereToMove.rotation));
    }

    IEnumerator Transition(Vector3 whereToMove, Quaternion rotateTo)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float timeElapsed = 0;

        while (timeElapsed < transitionTime)
        {
            float t = timeElapsed / transitionTime;

            transform.position = Vector3.Lerp(startPos, whereToMove, t);
            transform.rotation = Quaternion.Slerp(startRot, rotateTo, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = whereToMove;
        transform.rotation = rotateTo;
        Debug.Log("Camera moved to " + whereToMove);
        Debug.Log("Camera rotated to " + rotateTo);

    }
    public void MoveLeft()
    {
        if(index == 0)
        {
            index = CameraPositions.Length - 1;
        }
        else
        index--;

        MoveCameraTo(CameraPositions[index]);
        shopDataController.ChangeData((Weapon)CameraPositions[index].gameObject.GetComponent<DataHolder>().DataObject);
    }
    public void MoveRight()
    {
        if (index == CameraPositions.Length - 1)
        {
            index = 0;
        }
        else
        index++;

        MoveCameraTo(CameraPositions[index]);
        shopDataController.ChangeData((Weapon)CameraPositions[index].gameObject.GetComponent<DataHolder>().DataObject);
    }
}
