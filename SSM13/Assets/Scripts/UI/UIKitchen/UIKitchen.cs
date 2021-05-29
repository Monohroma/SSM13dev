using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Recipes;

namespace UI
{
    public class UIKitchen : MonoBehaviour
    {
        public GameObject UIKitchenPanelObj;
        public Kitchen currentKitchen;
        public GameObject kitchenRecipePanelPrefab;
        public RectTransform kitchenRecipePanelTransform;
        public GameObject kitchenCurrentPanelPrefab;
        public RectTransform kitchenCurrentPanelTransform;
        public List<UIKitchenRecipePanel> recipesPanels;
        public List<UIKitchenCurrentPanel> currentPanels;

        private void Start()
        {
            Recipe[] recipes = GameItemDatabase.GetRecipes();
            foreach (var item in recipes)
            {
                GameObject o = Instantiate(kitchenRecipePanelPrefab, kitchenRecipePanelTransform);
                UIKitchenRecipePanel uikrp = o.GetComponent<UIKitchenRecipePanel>();
                uikrp.Setup(item, this);
                recipesPanels.Add(uikrp);
                kitchenRecipePanelTransform.sizeDelta += new Vector2(0, uikrp.GetComponent<RectTransform>().sizeDelta.y);
            }
        }

        public void Setup(Kitchen kitchen)
        {
            if(currentKitchen != null)
            {
                currentKitchen.OnCookingRecipeAdd -= OnCookingAdd;
                currentKitchen.OnCookingRecipeRemove -= OnCookingRemove;
            }
            currentKitchen = kitchen;
            currentKitchen.OnCookingRecipeAdd += OnCookingAdd;
            currentKitchen.OnCookingRecipeRemove += OnCookingRemove;
            foreach (var item in currentPanels)
            {
                Destroy(item.gameObject);
            }
            currentPanels.Clear();
            kitchenCurrentPanelTransform.sizeDelta = new Vector2(kitchenCurrentPanelTransform.sizeDelta.x, 0);
            foreach (var item in currentKitchen.CurrentCookingRecipes)
            {
                OnCookingAdd(item);
            }
        }

        public void CookRecipe(Recipe recipe)
        {
            currentKitchen.Cook(recipe);
        }

        public void OnCookingAdd(CookingRecipe cr)
        {
            GameObject o = Instantiate(kitchenCurrentPanelPrefab, kitchenCurrentPanelTransform) as GameObject;
            UIKitchenCurrentPanel uikcp = o.GetComponent<UIKitchenCurrentPanel>();
            uikcp.Setup(cr);
            currentPanels.Add(uikcp);
            kitchenCurrentPanelTransform.sizeDelta += new Vector2(0, uikcp.GetComponent<RectTransform>().sizeDelta.y);
        }

        public void OnCookingRemove(CookingRecipe cr)
        {
            UIKitchenCurrentPanel uikcp = currentPanels.Find(x => x.cookingRecipe == cr);
            if(uikcp != null)
            {
                kitchenCurrentPanelTransform.sizeDelta -= new Vector2(0, uikcp.GetComponent<RectTransform>().sizeDelta.y);
                Destroy(uikcp.gameObject);
                currentPanels.Remove(uikcp);
            }
        }

        public void UpdateCookingRecipe()
        {
            foreach (var item in currentPanels)
            {
                item.UpdateParametrs();
            }
        }

        private void FixedUpdate()
        {
            UpdateCookingRecipe();
        }

        public void Show(Kitchen kitchen)
        {
            Setup(kitchen);
            UIKitchenPanelObj.SetActive(true);
        }

        public void Hide()
        {
            UIKitchenPanelObj.SetActive(false);
        }
    }
}
