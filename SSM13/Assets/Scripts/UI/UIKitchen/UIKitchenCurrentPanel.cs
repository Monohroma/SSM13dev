using Recipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIKitchenCurrentPanel : MonoBehaviour
    {
        public Image item;
        public Slider cookingSlider;
        public CookingRecipe cookingRecipe => _cookingRecipe;
        private CookingRecipe _cookingRecipe;
        public void Setup(CookingRecipe cr)
        {
            _cookingRecipe = cr;
            item.sprite = cr.Recipe.RecipeResult.ItemSprite;
        }

        public void UpdateParametrs()
        {
            cookingSlider.value = _cookingRecipe.GetProcent();
        }
    }
}
