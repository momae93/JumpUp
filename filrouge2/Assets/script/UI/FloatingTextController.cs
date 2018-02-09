using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    private static FloatingText popupText;
    private static FloatingText popupTextReverse;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("DifficultyCanvas");
        popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        popupTextReverse = Resources.Load<FloatingText>("Prefabs/PopupTextParentReverse");
    }

    public static void CreateFloatingText(string text)
    {
        FloatingText instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = canvas.transform.position;
        instance.SetText(text);

        FloatingText instance2 = Instantiate(popupTextReverse);
        instance2.transform.SetParent(canvas.transform, false);
        instance2.transform.position = canvas.transform.position;
        instance2.SetText("Are you ready to die ?");
    }
}
