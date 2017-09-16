﻿using UnityEngine;

public class CollectibleItem : MonoBehaviour {

    public InventoryItem itemType;
    public SpriteRenderer art;
    public GameObject itemPopup;

    private GameObject uiParent;
    private PlayerMachine player;

    void Awake() {
        art.sprite = itemType.icon;
        uiParent = GameObject.FindGameObjectWithTag("UIParent");
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            player = other.gameObject.GetComponent<PlayerMachine>();

            GameObject.FindGameObjectWithTag("Backpack").GetComponent<Backpack>().items.Add(itemType);
            ItemPopup popup = Instantiate(itemPopup, uiParent.transform).GetComponent<ItemPopup>();
            popup.player = player;
            popup.item = itemType;
            popup.startPopup(itemType, player);
            Destroy(gameObject);
        }
    }

}
