using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CraftingSystem : MonoBehaviour
{
    public List<CraftingRecipeSO> craftingRecipeSOList;
    public BoxCollider placeItemAreaBoxCollider;
    private CraftingRecipeSO craftingRecipeSO;
    public Transform itemSpawnPoint;

    private void Awake()
    {
        NextRecipe();
    }
    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => Craft());
    }
   
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       
       
    }
    public void NextRecipe()
    {
        
            int index = craftingRecipeSOList.IndexOf(craftingRecipeSO);
            index = (index + 1) % craftingRecipeSOList.Count;
            craftingRecipeSO = craftingRecipeSOList[index];
        

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
                Debug.Log("Found item: " + itemSOHolder.itemSO.itemName);
                inputItemList.Remove(itemSOHolder.itemSO);
            }
        }

        if (inputItemList.Count == 0)
        {
            Debug.Log("Yes");
            Instantiate(craftingRecipeSO.outputItemSO, itemSpawnPoint.position, itemSpawnPoint.rotation);
        }else
        {
            Debug.Log("No");
        }
    }
}
