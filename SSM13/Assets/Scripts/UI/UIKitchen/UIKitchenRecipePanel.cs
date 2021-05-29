using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Recipes;
using Storage;

namespace UI
{
    public class UIKitchenRecipePanel : MonoBehaviour
    {
        public Image item1;
        public Image item2;
        public Image item3;
        public Image item4;
        public Image result;
        public Button button;
        private Recipe _recipe;
        private UIKitchen _kitchen;
        public void Setup(Recipe recipe, UIKitchen kitchen)
        {
            _recipe = recipe;
            _kitchen = kitchen;
            GameItem[] items = recipe.RecipeIngredients;
            if(items.Length > 0)
            {
                item1.sprite = items[0].ItemSprite;
                item1.enabled = true;
            }
            else
            {
                item1.enabled = false;
            }
            if (items.Length > 1)
            {
                item2.sprite = items[1].ItemSprite;
                item2.enabled = true;
            }
            else
            {
                item2.enabled = false;
            }
            if (items.Length > 2)
            {
                item3.sprite = items[2].ItemSprite;
                item3.enabled = true;
            }
            else
            {
                item3.enabled = false;
            }
            if (items.Length > 3)
            {
                item4.sprite = items[3].ItemSprite;
                item4.enabled = true;
            }
            else
            {
                item4.enabled = false;
            }
            result.sprite = recipe.RecipeResult.ItemSprite;
        }

        public void Click()
        {
            _kitchen.CookRecipe(_recipe);
        }
    }
}
