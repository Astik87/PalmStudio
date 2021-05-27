using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public Slot[] slots;

    public bool add(GameObject obj, string name, int count, EventTrigger.Entry entry)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isFull || slots[i].ObjName == name)
            {
                return slots[i].add(obj, name, count, entry);
            }
        }

        return false;
    }

    public void remove(string name)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ObjName == name) slots[i].remove();
        }
    } 

}
