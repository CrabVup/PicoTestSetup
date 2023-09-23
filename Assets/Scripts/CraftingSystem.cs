using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public List<CraftingRecipeSO> craftingRecipesSOList;
    public BoxCollider placeItemAreaBoxCollider;
    private CraftingRecipeSO craftingRecipeSO;

    private void Awake()
    {
       
    }
    public void Craft()
    {
        Debug.Log("Craft");
        Collider[] colliderArray = Physics.OverlapBox(
                transform.position + placeItemAreaBoxCollider.center,
                placeItemAreaBoxCollider.size,
                placeItemAreaBoxCollider.transform.rotation);

        List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSO.inputItemSOList);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ItemSOHolder itemSOHolder))
            {
                inputItemList.Remove(itemSOHolder.itemSO);
            }
        }

        if (inputItemList.Count == 0)
        {
            Debug.Log("Yes");
        }else
        {
            Debug.Log("No");
        }
    }
}
