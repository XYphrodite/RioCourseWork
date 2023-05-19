namespace RioCourseWork.Data
{
    public class Initializer
    {
        private readonly ApplicationContext context;

        public Initializer(ApplicationContext context)
        {
            this.context = context;
        }

        public async void Initialize()
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
