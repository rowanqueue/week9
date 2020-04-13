using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    public int index = 0;
    public Item item;
    public TextMesh nameDisplay;
    public TextMesh idDisplay;
    public TextMesh recipeDisplay;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            index++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            index--;
        }
        index = (index+RecipeLoader.instance.itemDatabase.Count)%RecipeLoader.instance.itemDatabase.Count;
        
        item = RecipeLoader.instance.itemDatabase[index];
        nameDisplay.text = "Name: "+item.name;
        idDisplay.text = "ID: "+item.id;
        recipeDisplay.text = "Recipe: "+item.recipe;
    }
}
