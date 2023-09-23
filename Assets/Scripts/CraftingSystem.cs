using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public CraftingRecipeSO[] recipes;

    public bool Craft(CraftingRecipeSO recipe)
    {
        // Check if the player has all the required input items for this recipe.
        foreach (ItemSO inputItem in recipe.inputItemSOList)
        {
            if (!InventoryContains(inputItem))
            {
                Debug.Log("Missing required item: " + inputItem.itemName);
                return false; // Crafting failed
            }
        }

        // Remove the input items from the player's inventory.
        foreach (ItemSO inputItem in recipe.inputItemSOList)
        {
            RemoveItemFromInventory(inputItem);
        }

        // Add the output item to the player's inventory.
        AddItemToInventory(recipe.outputItemSO);

        Debug.Log("Crafted: " + recipe.outputItemSO.itemName);
        return true; // Crafting successful
    }

    private bool InventoryContains(ItemSO item)
    {
        // Check if the player's inventory contains the specified item.
        // You'll need to implement this method based on your inventory system.
        return false;
    }

    private void RemoveItemFromInventory(ItemSO item)
    {
        // Remove the specified item from the player's inventory.
        // You'll need to implement this method based on your inventory system.
    }

    private void AddItemToInventory(ItemSO item)
    {
        // Add the specified item to the player's inventory.
        // You'll need to implement this method based on your inventory system.
    }
}
