using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;

    private List<string> _keyInventory;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _keyInventory = new List<string>();
    }
    // Update is called once per frame
    void Update()
    {
        var rotation = new Vector3(0, Input.GetAxis("Horizontal") * _rotSpeed * Time.deltaTime, 0);
        
        transform.Rotate(rotation);

        Vector3 movement = Vector3.zero;

        if (_controller.isGrounded)
        {
            movement = transform.forward * (Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime);
        }
        
        movement.y += Physics.gravity.y * Time.deltaTime;
        
        _controller.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Unlockable"))
        {
            var unlockable = hit.collider.gameObject.GetComponent<IUnlockable>();
            if (unlockable.IsLocked == false)
            {
                return;
            }

            var unlocked = false;
            foreach (var key in _keyInventory)
            {
                if (unlockable.TryUnlock(key))
                {
                    Debug.Log("Unlocked");
                    unlocked = true;
                }
            }

            if (!unlocked)
            {
                EventManager.PublishUIEvent(EventManager.UIEvent.ChestLockedEvent);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            var pickable = other.gameObject.GetComponent<IPickable>();
            if (pickable is IUnlocker unlocker)
            {
                Debug.Log("Got key");
                pickable.PickedUp();
                _keyInventory.Add(unlocker.UnlockerID);
                other.gameObject.SetActive(false);
            }
        }
    }
}
