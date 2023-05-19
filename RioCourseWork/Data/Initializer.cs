namespace RioCourseWork.Data
{
    public class Initializer
    {
        public static async void Initialize(ApplicationContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
