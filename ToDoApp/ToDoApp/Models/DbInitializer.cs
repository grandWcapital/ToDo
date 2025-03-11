namespace ToDoApp.Models
{
    public class DbInitializer
    {
        public static void Seed(ToDoAppDbContext context)
        {
            if (!context.Category.Any())
            {
                context.Category.AddRange(
                    new Category { Name = "Work" },
                    new Category { Name = "Home" },
                    new Category { Name = "Personal" }
                );
                context.SaveChanges(); // ✅ Теперь категории точно сохранятся перед работой с ними
            }

            if (!context.Duties.Any())
            {
                var workCategory = context.Category.FirstOrDefault(c => c.Name == "Work");

                if (workCategory != null) // 🔹 Проверяем, что категория существует
                {
                    context.Duties.AddRange(
                        new Duty
                        {
                            Title = "Work on project",
                            Description = "Work on project",
                            Category = workCategory, // ✅ Используем сохранённую категорию
                            Priority = Priority.High,
                            Status = Status.InProgress,
                            Duration = new TimeSpan(1, 0, 0),
                            DueDate = new DateTime(2021, 12, 31)
                        }
                    );
                    context.SaveChanges(); // ✅ Теперь сохраняем задачи
                }
            }
        }
    }
}
