using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Item item;
    Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick = new Button.ButtonClickedEvent();
        button.onClick.AddListener(() =>
        {
            var wasCombined = InventoryManager.TryCombination(item);
            if (wasCombined)
                Destroy(gameObject);
        });
    }
}
