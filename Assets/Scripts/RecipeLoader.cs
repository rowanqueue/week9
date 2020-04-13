using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeLoader : MonoBehaviour
{
    public static RecipeLoader instance;
    public TextAsset itemDatabaseText;
    public List<Item> itemDatabase;
    public void Awake(){
        instance  =this;
        InitializeDatabase();
        Debug.Log(itemDatabase.Count);
    }
    public void InitializeDatabase(){
        itemDatabase = new List<Item>();
        string[] lines = itemDatabaseText.text.Split('\n');
        for(int i = 5; i < lines.Length;i++){
            string[] splitLine = lines[i].Split(',');
            if(splitLine[0] != ""){
                Item item = new Item(splitLine);
                itemDatabase.Add(item);
            }
        }
    }
    public Item FindItemByID(int id){
        foreach(Item item in itemDatabase){
            if(item.id == id){
                return item;
            }
        }
        return null;
    }
    public Item FindItemByID(string id){
        return FindItemByID(int.Parse(id));
    }
}
public enum ItemType : byte{
    Consumable,
    Crafting
}
public class Item{
    public string name;
    public int id;
    public string iconName;
    public Recipe recipe;
    public ItemType type;
    public Item(string[] line){
        name = line[0];
        id = int.Parse(line[1]);
        type = (ItemType)System.Enum.Parse(typeof(ItemType),line[2]);
        iconName = line[3];
        recipe = new Recipe(line[4]);
    }
}
public class Recipe{
    public Item product;
    public List<Item> ingredients;
    public string display;

    public Recipe(string recipe){
        ingredients = new List<Item>();
        string[] splitRecipe = recipe.Split(':');
        product = RecipeLoader.instance.FindItemByID(splitRecipe[0]);
        string[] splitIngredients = splitRecipe[1].Split('-');
        for(int i = 0; i < splitIngredients.Length;i++){
            Item item = RecipeLoader.instance.FindItemByID(splitIngredients[i]);
            ingredients.Add(item);
        }
        display = recipe;
    }
    public override string ToString(){
        return display;
    }
}
