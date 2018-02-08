using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

    // Use this for initialization
    public Animator animator;
    private Text levelText;

    void OnEnable()
    {
        Animate(animator);
    }

    private void Animate(Animator animator)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Debug.Log(clipInfo.Length);
        Destroy(gameObject, clipInfo[0].clip.length);
        levelText = animator.GetComponent<Text>();
    }

    public void SetText(string text)
    {
        levelText.text = text;
    }
}
