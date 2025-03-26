using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
    public enum UIEvent
    {
        KeyPickUpEvent,
        ChestOpenEvent,
        ChestLockedEvent
    }
    
    private static readonly Dictionary<UIEvent, Delegate> _uiEventDictionary = new Dictionary<UIEvent, Delegate>();

    // Register to an event
    public static void SubscribeToUIEvents(UIEvent uiEvent, Action listener)
    {
        if (_uiEventDictionary.TryGetValue(uiEvent, out Delegate existingDelegate))
        {
            _uiEventDictionary[uiEvent] = Delegate.Combine(existingDelegate, listener);
        }
        else
        {
            _uiEventDictionary[uiEvent] = listener;
        }
    }
    
    // Unregister from an event
    public static void UnsubscribeToUIEvents(UIEvent uiEvent, Action listener)
    {
        if (_uiEventDictionary.TryGetValue(uiEvent, out Delegate existingDelegate))
        {
            var newDelegate = Delegate.Remove(existingDelegate, listener);
            if (newDelegate == null)
            {
                _uiEventDictionary.Remove(uiEvent);
            }
            else
            {
                _uiEventDictionary[uiEvent] = newDelegate;
            }
        }
    }
    
    // Publish an event
    public static void PublishUIEvent(UIEvent uiEvent)
    {
        if (_uiEventDictionary.TryGetValue(uiEvent, out Delegate existingDelegate))
        {
            (existingDelegate as Action)?.Invoke();
        }
    }
}
