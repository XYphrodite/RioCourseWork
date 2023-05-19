namespace RioCourseWork.Data
{
    public class Initializer
    {
        public static async Task Initialize(ApplicationContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
