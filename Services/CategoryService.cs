using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Cake_palace.Exceptions;
using Cake_palace.models;
using Cake_palace.Repository;

namespace Cake_palace.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> AddCategory(Category category)
        {
           
            return await _repository.AddCategory(category);
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var cat = await _repository.GetCategory(id);
            if (cat == null)
            {
                throw new CategoryNotFoundException("Category with this id not found");
            }
            else
            {
                return await _repository.DeleteCategory(id);
            }
           
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _repository.GetCategories();
        }

        public async Task<Category> GetCategory(int id)
        {
            var cat = await _repository.GetCategory(id);
            if(cat == null)
            {
                throw new CategoryNotFoundException("Category with this id not found");
            }
            return cat;

        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var cat = await _repository.GetCategory(id);
            if(cat == null)
            {
                throw new CategoryNotFoundException("Category with this id not found");
            }
            else
            {
                return await _repository.UpdateCategory(id,category);
            }
        }
    }
}
