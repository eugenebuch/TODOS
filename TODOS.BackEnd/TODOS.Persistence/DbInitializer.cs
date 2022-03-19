namespace TODOS.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TodosDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}