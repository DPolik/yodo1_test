using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IUnlockable
{
    [SerializeField] private string _unlockerID;

    public string UnlockerID => _unlockerID;
    public bool IsLocked { get; private set; } = true;

    public bool TryUnlock(string unlockerID)
    {
        if (unlockerID.Equals(_unlockerID))
        {
            Debug.Log("Chest unlocked");
            EventManager.PublishUIEvent(EventManager.UIEvent.ChestOpenEvent);
            IsLocked = false;
            return true;
        }

        return false;
    }
}
