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
    public GameObject craftVfx;
 
    public List<VirusTcell> virusTcells;
    public List<VirusTcell2> virusTcells2;
    public List<VirusTcell3> virusTcells3;

    public AudioSource craftDone;

    public bool isCrafted;

    private void Awake()
    {
        //NextRecipe();
    }
    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => CraftVfx());
        craftVfx.SetActive(false);

        isCrafted = false;
    }
   
    void Update()
    {
       
            //NextRecipe();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            CraftVfx();
        }
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

    public void CraftVfx()
    {
        craftVfx.SetActive(true);
        isCrafted = true;
        NextRecipe();
        Invoke("Craft", 1f);
    }
    public void Craft()
    {
        
        Debug.Log("Craft");
        Collider[] colliderArray = Physics.OverlapBox(
                transform.position + placeItemAreaBoxCollider.center,
                placeItemAreaBoxCollider.size,
                placeItemAreaBoxCollider.transform.rotation);


        List<ItemSO> inputItemList = new List<ItemSO>(craftingRecipeSO.inputItemSOList);
        List<GameObject> consumeItemGameObjectList = new List<GameObject>();
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out ItemSOHolder itemSOHolder))
            {
                if (inputItemList.Contains(itemSOHolder.itemSO))
                {
                    Debug.Log("Found item: " + itemSOHolder.itemSO.itemName);
                    inputItemList.Remove(itemSOHolder.itemSO);
                    consumeItemGameObjectList.Add(collider.gameObject);
                }
  
            }
        }

        if (inputItemList.Count == 0)
        {
            Debug.Log("Yes");
            craftDone.Play();
            Instantiate(craftingRecipeSO.outputItemSO, itemSpawnPoint.position, itemSpawnPoint.rotation);
            //Instantiate(craftingVFX, itemSpawnPoint.position, itemSpawnPoint.rotation);
        
            foreach (GameObject consumeItemGameObject in consumeItemGameObjectList)
            {
                Destroy(consumeItemGameObject);
            }
        }
        craftVfx.SetActive(false);
        foreach (VirusTcell virusTcell in virusTcells)
        {
            virusTcell.FindGameObjectsWithMarker();
        }
        foreach (VirusTcell2 virusTcell2 in virusTcells2)
        {
            virusTcell2.FindGameObjectsWithMarkerB();
        }
        foreach (VirusTcell3 virusTcell3 in virusTcells3)
        {
            virusTcell3.FindGameObjectsWithMarkerC();
        }

    }
}
