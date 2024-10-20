using System.Collections;
using UnityEngine;

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

    private UIEvents UIEvents;
    int index;
    public float transitionTime;


    public bool transitionEnded;
    void Start()
    {
        this.UIEvents = UIEvents.Instance;
        CurrentPositions = WeaponPositions;
        transitionEnded = true;
        index = 0;

        /*UIEvents.ShopMoveLeftClicked += MoveLeft;
        UIEvents.ShopMoveRightClicked += MoveRight;

        UIEvents.ShopWeaponsClicked += WeaponsClicked;
        UIEvents.ShopThrowablesClicked += ThrowablesClicked;
        UIEvents.ShopSpecialsClicked += SpecialsClicked;*/


        MoveCameraTo(CurrentPositions[index]);
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
        //Debug.Log("Camera moved to " + whereToMove);
        //Debug.Log("Camera rotated to " + rotateTo);

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
            
        }
    }
    public void WeaponsClicked()
    {
        if (CurrentPositions != WeaponPositions)
        {
            CurrentPositions = WeaponPositions;
            index = 0;
            MoveCameraTo(WeaponPositions[index]);

        }

    }
    public void ThrowablesClicked()
    {
        if (CurrentPositions != GrenadePositions)
        {
            CurrentPositions = GrenadePositions;
            index = 0;
            MoveCameraTo(GrenadePositions[index]);

        }

    }
    public void SpecialsClicked()
    {
        if (CurrentPositions != SpecialPositions)
        {
            CurrentPositions = SpecialPositions;
            index = 0;
            MoveCameraTo(SpecialPositions[index]);
            
        }


    }

}
