using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget
{
    public static GameObject targetObject = null;
    public static bool isInteractable = false;
    public static string tag = "";
    public static void clear()
    {
        targetObject = null;
        isInteractable = false;
        tag = "";
    }
    public static void set(Collider obj)
    {
        targetObject = obj.gameObject;
        tag = obj.tag;
        isInteractable = System.Array.IndexOf(GlobalConstants.interactableObjectTags, obj.tag) >= 0;
    }
}
