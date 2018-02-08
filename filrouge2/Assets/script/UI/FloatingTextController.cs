using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("DifficultyCanvas");
        if (!popupText)
            popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
    }

    public static void CreateFloatingText(string text)
    {
        FloatingText instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = canvas.transform.position;
        Debug.Log(text);
        instance.SetText(text);
    }
}
