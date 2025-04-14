using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUIController : MonoBehaviour
{
    public GameObject BagUIProfab;
    public GameObject BagItemUI;
    public Transform BagItemContainer;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BagItemUI.SetActive(!BagItemUI.activeSelf);
            if (BagItemUI.activeSelf)
            {
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        foreach (Transform child in BagItemContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (BagItem item in BagController.instance.Items)
        {
            GameObject itemUI = Instantiate(BagUIProfab, BagItemContainer);
            itemUI.transform.Find("Icon").GetComponent<Image>().sprite = item.item.itemSprite;
            itemUI.transform.Find("Text").GetComponent<Text>().text = item.item.itemName;
        }
    }
}
