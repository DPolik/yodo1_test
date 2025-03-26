using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnlockable
{
    public string UnlockerID { get; }
    public bool IsLocked { get; }

    public bool TryUnlock(string unlockerID);
}
