using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : CoreComponents
{
    [Header("Pick Up Ability")]
    [SerializeField] private Transform _hands;

    [SerializeField] private int _numberOfObjectsInHands;

    public int NumberOfObjectsInHands { get => _numberOfObjectsInHands; set => _numberOfObjectsInHands = value; }

    public void PickUpAbility(RaycastHit2D p_handsRaycast)
    {
        if (p_handsRaycast.collider != null)
        {
            p_handsRaycast.collider.gameObject.transform.parent = _hands;
            p_handsRaycast.collider.gameObject.transform.position = _hands.position;
            p_handsRaycast.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    public void PutDownAbility(RaycastHit2D p_handsRaycast)
    {
        if(p_handsRaycast.collider != null)
        {
            p_handsRaycast.collider.gameObject.transform.parent = null;
            p_handsRaycast.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public void AddObjects() => _numberOfObjectsInHands++;
    public void RemoveObjects() => _numberOfObjectsInHands--;
}
