using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalConstants
{
    public const float playerGrabDistance = 1.9f;
    public const float playerSpeed = 3f;
    public const float playerSpeedSprinting = 4.5f;
    public const float playerJumpHeight = 2f;
    public const float crosshairSizeDefault = 6;
    public const float crosshairSizeSelected = 12;
    public static readonly string[] interactableObjectTags = { "Block", "Beer", "Crowbar" };
}
