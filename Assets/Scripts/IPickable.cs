using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    public enum PickableType
    {
        Key
    }
    public void PickedUp();
}
