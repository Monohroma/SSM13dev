using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using Ark;
using Storage;
using Recipes;
using UI;

public class Kitchen : Bay
{
    public int cookingMaximum = 5;
    public bool autoCook = false;
    public Action<CookingRecipe> OnCookingRecipeAdd;
    public Action<CookingRecipe> OnCookingRecipeRemove;
    public List<CookingRecipe> CurrentCookingRecipes => cookingRecipes;
    private Recipe[] recipes;
    private List<CookingRecipe> cookingRecipes = new List<CookingRecipe>();
    protected override void Start()
    {
        base.Start();
        recipes = GameItemDatabase.GetRecipes();
    }

    private void FixedUpdate()
    {
        if (Energetics.Instance.IsPower)
        {
            Powered = true;
        }
        else
            Powered = false;
        if (WorkersInBay.Count > 0)
        {
            Active = true;
            if (Energetics.Instance.IsPower)
            {
                if (cookingRecipes.Count < cookingMaximum && autoCook)
                {
                    foreach (Recipe item in recipes)
                    {
                        if (cookingRecipes.Count < cookingMaximum)
                        {
                            if (CheckIngredientsContain(item))
                            {
                                StartCook(item);
                            }
                        }
                    }
                }
                for (int i = 0; i < cookingRecipes.Count; i++)
                {
                    if (cookingRecipes[i].Update(Time.fixedDeltaTime))
                    {
                        EndCook(cookingRecipes[i].Recipe);
                        OnCookingRecipeRemove?.Invoke(cookingRecipes[i]);
                        cookingRecipes.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        else
            Active = false;
    }

    private bool CheckIngredientsContain(Recipe recipe, bool remove = true)
    {
        Dictionary<int, int> dictinory = new Dictionary<int, int>();
        foreach (GameItem item in recipe.RecipeIngredients)
        {
            if(dictinory.ContainsKey(item.ItemID))
            {
                dictinory[item.ItemID]++;
            }
            else
            {
                dictinory.Add(item.ItemID, 1);
            }
        }
        foreach (var item in dictinory)
        {
            if(!Inventory.Instance.ContainItem(item.Key, item.Value))
            {
                return false;
            }
        }
        if(remove)
        {
            foreach (var item in dictinory)
            {
                Inventory.Instance.GetItem(item.Key).RemoveCount(item.Value);
            }
        }
        return true;
    }

    private void StartCook(Recipe recipe)
    {
        AddConsumptionEnergy(recipe.RecipeEnergyNeed);
        var cr = new CookingRecipe(recipe);
        cookingRecipes.Add(cr);
        OnCookingRecipeAdd?.Invoke(cr);
    }

    public void EndCook(Recipe recipe)
    {
        Debug.Log($"Done coocking {recipe.RecipeName}");
        Inventory.Instance.AddItem(recipe.RecipeResult);
        RemoveConsumptionEnergy(recipe.RecipeEnergyNeed);
    }

    public void StartCook(string result)
    {
        foreach (Recipe item in recipes)
        {
            if(item.RecipeName == result)
            {
                if (CheckIngredientsContain(item))
                {
                    StartCook(item);
                }
                return;
            }
        }
    }

    public void Cook(Recipe recipe)
    {
        if (cookingRecipes.Count < cookingMaximum && CheckIngredientsContain(recipe))
        {
            StartCook(recipe);
        }
    }

    public void Cook(string result)
    {
        if(cookingRecipes.Count < cookingMaximum)
            StartCook(result);
    }

    public void OpenMenu()
    {
        UIManager.ShowKitchenBayMenu(this);
    }
}