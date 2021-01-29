using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int SlotId
    {
        get
        {
            return slotId;
        }
        set
        {
            slotId = value;
        }
    }
    [SerializeField]
    int slotId;

    public bool HasObject
    {
        get
        {
            return hasObject;
        }
    }
    bool hasObject;

    [SerializeField]
    CompositeObject obj;

    private void Update()
    {
        
    }

    public void AddObject(GameObject o)
    {
        if (HasObject)
            return;

        var t = Instantiate(o);
        t.transform.SetParent(transform);
        t.transform.localPosition = new Vector3(0, 0, -0.3f);

        hasObject = true;
        obj = o.GetComponent<CompositeObject>();
    }

    public bool ContainsSameObject(Slot slot)
    {
        if(obj != null && slot.HasObject && slot.obj != null)
        {
            return slot.obj.id == obj.id;
        }
        return false;
    }

    public void ClearSlot()
    {
        hasObject = false;
        Destroy(transform.GetChild(0).gameObject);
        obj = null;
    }

}
