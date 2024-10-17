using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CameraTransition : MonoBehaviour
{
    [SerializeField]
    private Transform[] WeaponPositions;

    [SerializeField]
    private Transform[] GrenadePositions;

    [SerializeField]
    private Transform[] SpecialPositions;

    [SerializeField]
    private Transform[] CurrentPositions;


    int index;
    public float transitionTime;

    [SerializeField]
    private ShopDataController shopDataController;

    private bool transitionEnded;
    void Start()
    {
        CurrentPositions = WeaponPositions;
        transitionEnded = true;
        index = 0;

        MoveCameraTo(CurrentPositions[0]);
        shopDataController.ChangeData((Weapon)CurrentPositions[index]?.gameObject.GetComponent<DataHolder>().DataObject);
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

        transitionEnded = true;

    }
    public void MoveLeft()
    {
        if (transitionEnded)
        {
            if (index == 0)
            {
                index = CurrentPositions.Length - 1;
            }
            else
                index--;

            transitionEnded = false;
            MoveCameraTo(CurrentPositions[index]);
            shopDataController.ChangeData((Weapon)CurrentPositions[index].gameObject.GetComponent<DataHolder>().DataObject);
        }
    }
    public void MoveRight()
    {
        if (transitionEnded)
        {
            if (index == CurrentPositions.Length - 1)
            {
                index = 0;
            }
            else
                index++;
            transitionEnded = false;
            MoveCameraTo(CurrentPositions[index]);
            shopDataController.ChangeData((Weapon)CurrentPositions[index]?.gameObject.GetComponent<DataHolder>().DataObject);
        }
    }
    public void WeaponsClicked()
    {
        if (CurrentPositions != WeaponPositions)
        {
            CurrentPositions = WeaponPositions;
            index = 0;
            MoveCameraTo(WeaponPositions[0]);
            shopDataController.ChangeData((Weapon)CurrentPositions[index]?.gameObject.GetComponent<DataHolder>().DataObject);
        }

    }
    public void ThrowablesClicked()
    {
        if (CurrentPositions != GrenadePositions)
        {
            CurrentPositions = GrenadePositions;
            index = 0;
            MoveCameraTo(GrenadePositions[0]);
            shopDataController.ChangeData((Weapon)CurrentPositions[index]?.gameObject.GetComponent<DataHolder>().DataObject);
        }
            
    }
    public void SpecialsClicked()
    {
        if(CurrentPositions != SpecialPositions)
        {
            CurrentPositions = SpecialPositions;
            index = 0;
            MoveCameraTo(SpecialPositions[0]);
            shopDataController.ChangeData((Weapon)CurrentPositions[index]?.gameObject.GetComponent<DataHolder>().DataObject);
        }
            

    }
    
}
