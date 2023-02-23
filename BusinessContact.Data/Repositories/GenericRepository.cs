using BusinessContact.Data.Configurations;
using BusinessContact.Data.IRepositories;
using BusinessContact.Domain.Commons;
using BusinessContact.Domain.Entities;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace BusinessContact.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Auditable
    {
        private string Path;
        private long LastId = 0;

        public GenericRepository()
        {
            StartUp();
        }

        private async void StartUp()
        {
            if (typeof(TEntity) == typeof(Users))
            {
                Path = DatabasePaths.USERS_PATH;
            }
            else if (typeof(TEntity) == typeof(Contacts))
            {
                Path = DatabasePaths.CONTACTS_PATH;
            }

            foreach (var model in await GetAllAsync())
            {
                if (model.Id > LastId)
                    LastId = model.Id;
            }
        }

        public async Task<TEntity> CreateAsync(TEntity model)
        {
            model.Id = ++LastId;
            var models = await GetAllAsync();
            models.Add(model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

            return model;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            List<TEntity> models = await GetAllAsync();
            var model = models.FirstOrDefault(x => x.Id == id);
            if (model is null)
            {
                return false;
            }

            models.Remove(model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));
            return true;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            string text = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(text))
            {
                text = "[]";
            }

            var result = JsonConvert.DeserializeObject<List<TEntity>>(text);

            return result;
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return (await GetAllAsync()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            var models = await GetAllAsync();
            var updatingModel = models.FirstOrDefault(x => x.Id == model.Id);

            if (updatingModel is null)
            {
                return null;
            }

            var index = models.IndexOf(model);

            models.Remove(updatingModel);

            model.LastUpdatedAt = updatingModel.LastUpdatedAt;
            models.Insert(index, model);

            File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

            return model;

        }

    }
}
