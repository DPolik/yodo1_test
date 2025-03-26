using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour, IPickable, IUnlocker
{
    [SerializeField] private string keyID;
    
    public void PickedUp()
    {
        //Any effects you want to add go here
        EventManager.PublishUIEvent(EventManager.UIEvent.KeyPickUpEvent);
    }

    public string UnlockerID => keyID;
}
