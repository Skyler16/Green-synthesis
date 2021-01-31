using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisPanel : MonoBehaviour
{
    [SerializeField]
    Slot[] slots;
    [SerializeField]
    int rows = 4, cols = 4;

    public int fullSlots = 0;

    public int panelSum = 0;

    public static SynthesisPanel Get
    {
        get
        {
            return instance;
        }
    }
    static SynthesisPanel instance;

    SynthesisData synData;

    private void Awake()
    {
        Slot[] cslots = GetComponentsInChildren<Slot>();
        slots = cslots;
        for(int i=0; i<slots.Length; ++i)
        {
            slots[i].SlotId = i;
        }

        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        synData = Resources.Load<SynthesisData>("Object List");
    }

    private void Update()
    {
        if (fullSlots == slots.Length)
        {
            Debug.Log("over");
            Game.Get.GameOver();
        }
    }

    public void PlaceObject(Slot slot, GameObject obj)
    {
        if (!slot.HasObject)
        {
            slot.AddObject(obj);

            bool needUpgrade = MergeAdjacentObjects(slot);
            while(needUpgrade)
            {
                slot.UpgradeToNewObject();
                needUpgrade = MergeAdjacentObjects(slot);
            }
        }
    }

    bool MergeAdjacentObjects(Slot slot)
    {
        int p = slot.SlotId;
        int[] p2d = ArrayIndex1Dto2D(p);
        int[] ids = { -1, -1, -1, -1 };
        if (p - cols >= 0) ids[0] = p - cols;
        if (p + cols < slots.Length) ids[1] = p + cols;
        if(p - 1 >= 0)
        {
            int[] t = ArrayIndex1Dto2D(p - 1);
            if (t[0] == p2d[0])
                ids[2] = p - 1;
        }
        if (p + 1 < slots.Length)
        {
            int[] t = ArrayIndex1Dto2D(p + 1);
            if (t[0] == p2d[0])
                ids[3] = p + 1;
        }

        bool needUpgrade = false;
        for(int i=0; i<4; ++i)
        {
            if(ids[i] > -1)
            {
                Slot s = slots[ids[i]];
                if (s)
                {
                    if (slot.ContainsSameObject(s))
                    {
                        s.ClearSlot();
                        Debug.Log("merge " + slot.SlotId + " + " + s.SlotId);
                        needUpgrade = true;
                    }
                }
            }
        }

        return needUpgrade;
    }

    int[] ArrayIndex1Dto2D(int idx)
    {
        int[] i = new int[2];
        i[0] = idx / cols;
        i[1] = idx % cols;
        return i;
    }

    
}
