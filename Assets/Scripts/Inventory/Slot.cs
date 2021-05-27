using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public string ObjName;
    public int count = -1;
    public GameObject countObj;
    public GameObject obj;
    public GameObject icon;
    public bool isFull = false;

    private void Update()
    {
        if (count == 0)
        {
            countObj.GetComponent<Text>().text = "";
            countObj.SetActive(false);
            Destroy(icon);
            obj = null;
            isFull = false;
            ObjName = null;
        }
    }

    public bool add(GameObject Lobj, string Lname, int Lcount, EventTrigger.Entry entry)
    {
        if (isFull && ObjName != Lname) return false;

        if (isFull && ObjName == Lname)
        {
            count += Lcount;
        }

        if(!isFull)
        {
            obj = Lobj;
            icon = obj.GetComponent<Pickup>().icon;
            icon = Instantiate(icon);
            icon.transform.SetParent(this.gameObject.transform);
            icon.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
            count = Lcount;
            ObjName = Lname;
            GetComponent<EventTrigger>().triggers.Add(entry);
            isFull = true;
        }
        
        countObj.GetComponent<Text>().text = count.ToString();
        countObj.SetActive(true);

        return true;

    }

    public void remove()
    {
        count--;
        countObj.GetComponent<Text>().text = count.ToString();
    }

}
