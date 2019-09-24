using Assets.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class DetailsAssets : MonoBehaviour
    {
        List<GameObject> slots = new List<GameObject>();

        public static void NewGeneratedObjects(GameObject slotPanel, GameObject slot1, GameObject item1, List<Equipment_Model> emList)
        {
            DetailsAssets da = new DetailsAssets();
            da.GeneratedObjects(slotPanel, slot1, item1, emList);
        }
        public static void NewDestroyedObjects(GameObject slotPanel)
        {
            DetailsAssets da = new DetailsAssets();
            da.DestroyedObjects(slotPanel);
        }

        public void GeneratedObjects(GameObject slotPanel, GameObject slot, GameObject item, List<Equipment_Model> emList)
        {
            for (int i = 0; i < emList.Count; i++)
            {
                slots.Add(Instantiate(slot));
                slots[i].transform.SetParent(slotPanel.transform);
                Objects(emList[i], item, i);
            }            
        }
        public void Objects(Equipment_Model em, GameObject item, int i)
        {
            GameObject itemObject = Instantiate(item);
            itemObject.transform.SetParent(slots[i].transform);
            itemObject.transform.position = Vector2.zero;
            itemObject.name = em.E_ID;

            Text TxtID = GameObject.Find(itemObject.name + "/name").GetComponent<Text>();
            Text TxtName = GameObject.Find(itemObject.name + "/Text (1)").GetComponent<Text>();
            Text TxtSpecifications = GameObject.Find(itemObject.name + "/Text (2)").GetComponent<Text>();
            Text TxtNumber = GameObject.Find(itemObject.name + "/Text (3)").GetComponent<Text>();
            Text TxtUnit = GameObject.Find(itemObject.name + "/Text (4)").GetComponent<Text>();
            Text TxtRemarks = GameObject.Find(itemObject.name + "/Text (5)").GetComponent<Text>();

            TxtID.text = "编号：" + em.E_ID;
            TxtName.text = "名称：" + em.E_Name;
            TxtSpecifications.text = "规格：" + em.E_Specifications;
            TxtNumber.text = "数量：" + em.E_Number;
            TxtUnit.text = "单位：" + em.E_Unit;
            TxtRemarks.text = "备注：" + em.E_Remarks;
        }

        public void DestroyedObjects(GameObject slotPanel)
        {
            int slotCloneCount = slotPanel.transform.childCount;
            if (slotCloneCount != 0)
            {
                for (int j = 0; j < slotCloneCount; j++)
                {
                    DestroyImmediate(GameObject.Find(slotPanel.name + "/slot(Clone)"));//立即销毁
                }
            }
        }
    }
}