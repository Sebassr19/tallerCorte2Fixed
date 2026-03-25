using System;
using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{

    [SerializeField] private ItemData _itemData;
    [SerializeField] private AudioClip sonidoRecolectar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonidoRecolectar, transform.position);
            GameManager.Instance.TotalItem(_itemData);
            Debug.Log($"Recolectaste un {_itemData.itemName}" + " El valor de item" + _itemData.itemValue);
            Destroy(gameObject);

        }    
    }
}
