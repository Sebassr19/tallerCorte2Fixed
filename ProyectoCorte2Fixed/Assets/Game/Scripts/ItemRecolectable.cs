using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private AudioClip sonidoRecolectar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ReferenceEquals(_itemData, null))
            {
                Debug.LogError("No hay ItemData asignado en " + gameObject.name);
                return;
            }

            if (ReferenceEquals(GameManager.Instance, null))
            {
                Debug.LogError("GameManager.Instance es null");
                return;
            }

            if (!ReferenceEquals(sonidoRecolectar, null))
            {
                AudioSource.PlayClipAtPoint(sonidoRecolectar, transform.position);
            }

            GameManager.Instance.SumarItem(_itemData.itemName, _itemData.itemValue);

            Debug.Log("Recolectaste: " + _itemData.itemName + " valor base: " + _itemData.itemValue);

            Destroy(gameObject);
        }
    }
}
