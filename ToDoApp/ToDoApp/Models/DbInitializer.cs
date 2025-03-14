namespace ToDoApp.Models
{
    public class DbInitializer
    {
        public static void Seed(ToDoAppDbContext context)
        {
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                     new Status{Name = "Not Started"},
                      new Status { Name = "In Progress" },
                        new Status { Name = "Finished" }
                    );
                context.SaveChanges();
            }
            if (!context.Priorities.Any())
            {
                context.Priorities.AddRange(
                     new Priority { Name = "Low" },
                      new Priority { Name = "Middle" },
                        new Priority { Name = "High" }
                    );
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                     new Category { Name = "Work" },
                      new Category { Name = "Home" },
                        new Category { Name = "Hobby" }
                    );
                context.SaveChanges();

            }

        }
    }
}
