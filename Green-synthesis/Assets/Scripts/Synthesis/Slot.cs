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
    SynthesisObject containObject;

    SynthesisData synData;

    private void Awake()
    {
        synData = Resources.Load<SynthesisData>("Object List");
    }

    public void AddObject(GameObject o)
    {
        ++SynthesisPanel.Get.fullSlots;

        GameObject obj = Instantiate(o);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = new Vector3(0, 0, -0.3f);

        hasObject = true;
        containObject = obj.GetComponent<SynthesisObject>();
        Debug.Log("add object: id = " + containObject.id + ", nextId = " + containObject.nextId);

        SynthesisPanel.Get.panelSum += (int)Mathf.Pow(2, containObject.id);

        //if (containObject.nextId == -1)
         //   ClearSlot();
    }

    public bool ContainsSameObject(Slot slot)
    {
        if(containObject != null && slot.HasObject && slot.containObject != null)
        {
            return slot.containObject.id == containObject.id;
        }
        return false;
    }

    public void ClearSlot()
    {
        --SynthesisPanel.Get.fullSlots;
        SynthesisPanel.Get.panelSum -= (int)Mathf.Pow(2, containObject.id);

        hasObject = false;
        Transform childTr = transform.GetChild(0);
        childTr.parent = null;
        Destroy(childTr.gameObject);
        containObject = null;
    }

    public void UpgradeToNewObject()
    {
        if(containObject != null)
        {
            if (containObject.nextId > 0)
            {
                GameObject newObj = synData.GetSynthesisGameObject(containObject.nextId);
                ClearSlot();
                AddObject(newObj);
                Game.Get.getScore += synData.scores[containObject.nextId];
            }
        }

    }
}
