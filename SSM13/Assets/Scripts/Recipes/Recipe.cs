using Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Recipes
{

    [CreateAssetMenu(menuName = "Item/Recipe", fileName = "New Recipe")]
    public class Recipe : ScriptableObject
    {
        [Header("Recipe values")]
        [SerializeField] private string Name;
        [SerializeField] private int ID;

        [TextArea]
        [SerializeField] private string Description;

        [Space(1f)]
        [Header("Items")]
        [SerializeField] private GameItem Result;
        [SerializeField] private GameItem[] ingredients;

        [Space(1f)]
        [Header("Parametrs")]
        [SerializeField] private float CookingTime;
        [SerializeField] private int EnergyNeed;

        public string RecipeName => Name;
        public int RecipeID => ID;
        public string RecipeDescription => Description;
        public GameItem RecipeResult => Result;
        public GameItem[] RecipeIngredients => ingredients;
        public float RecipeCookingTime => CookingTime;
        public int RecipeEnergyNeed => EnergyNeed;

    }
}
