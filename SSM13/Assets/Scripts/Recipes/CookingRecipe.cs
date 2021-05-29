namespace Recipes
{
    public class CookingRecipe
    {
        public Recipe Recipe => _recipe;
        private Recipe _recipe;
        private float timer;
        public CookingRecipe(Recipe recipe)
        {
            _recipe = recipe;
            timer = recipe.RecipeCookingTime;
        }

        public bool Update(float time)
        {
            if(timer - time < 0)
            {
                return true;
            }
            else
            {
                timer -= time;
                return false;
            }
        }

        public float GetProcent()
        {
            return ((_recipe.RecipeCookingTime - timer) / _recipe.RecipeCookingTime);
        }
    }
}
