using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositePanel : MonoBehaviour
{
    [SerializeField]
    Slot[] panel;
    [SerializeField]
    int rows = 2, cols = 2;

    public static CompositePanel Get
    {
        get
        {
            return instance;
        }
    }
    static CompositePanel instance;

    private void Awake()
    {
        Slot[] slots = GetComponentsInChildren<Slot>();
        panel = slots;
        for(int i=0; i<panel.Length; ++i)
        {
            panel[i].SlotId = i;
        }

        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void PlaceObject(Slot slot, GameObject obj)
    {
        slot.AddObject(obj);

        MergeAdjacentObjects(slot);
    }

    void MergeAdjacentObjects(Slot slot)
    {
        int p = slot.SlotId;
        int[] p2d = ArrayIndex1Dto2D(p);
        int[] ids = { -1, -1, -1, -1 };
        if (p - cols >= 0) ids[0] = p - cols;
        if (p + cols < panel.Length) ids[1] = p + cols;
        if(p - 1 >= 0)
        {
            int[] t = ArrayIndex1Dto2D(p - 1);
            if (t[0] == p2d[0])
                ids[2] = p - 1;
        }
        if (p + 1 < panel.Length)
        {
            int[] t = ArrayIndex1Dto2D(p + 1);
            if (t[0] == p2d[0])
                ids[3] = p + 1;
        }

        for(int i=0; i<4; ++i)
        {
            if(ids[i] > -1)
            {
                Slot s = panel[ids[i]];
                if (s)
                {
                    if (slot.ContainsSameObject(s))
                        s.ClearSlot();
                }
            }
        }
    }

    int[] ArrayIndex1Dto2D(int idx)
    {
        int[] i = new int[2];
        i[0] = idx / cols;
        i[1] = idx % cols;
        return i;
    }
}
