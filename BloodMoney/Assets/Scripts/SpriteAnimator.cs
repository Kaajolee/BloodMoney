using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer _spriteRenderer;

    public float animSpeed;

    public List<Sprite> sprites;

    private int index = 0;

    [SerializeField]
    private bool duringRuntime;

    private void Start()
    {
        if(duringRuntime)
            StartAnimation();
    }
    private IEnumerator StartAnim()
    {
        while (true)
        {

            if (index >= sprites.Count)
            {
                index = 0;
                yield break;
            }   
            else
                _spriteRenderer.sprite = sprites[index];
            index++;
            yield return new WaitForSeconds(animSpeed);
        }
    }
    public void StartAnimation()
    {
        StartCoroutine(StartAnim());
    }
}
