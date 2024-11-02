using System.Reflection;

public static class CodeGenerator
{
    public static void Generate(string modelName)
    {
        try
        {
            // گرفتن مسیر اصلی سولوشن به کمک Reflection
            string solutionDirectory = "C:\\Users\\USER\\Desktop\\Bot\\BlazerTest";

            // مسیرهای کامل به دایرکتوری‌های سولوشن
            string applicationPath = Path.Combine(solutionDirectory, "Application");
            string infrastructurePath = Path.Combine(solutionDirectory, "Infrastructure");

            // دایرکتوری‌ها رو ایجاد می‌کنیم اگر وجود ندارند
            //Directory.CreateDirectory(Path.Combine(applicationPath, "IInfrastructure"));
            //Directory.CreateDirectory(Path.Combine(applicationPath, "IService"));
            //Directory.CreateDirectory(Path.Combine(infrastructurePath, "Repository"));
            //Directory.CreateDirectory(Path.Combine(applicationPath, "Service"));

            string repositoryInterface = $"namespace Application.IInfrastructure\n{{\n\tpublic interface I{modelName}Repository: IRepository<{modelName}>\n\t{{\n\t}}\n}}";
            string serviceInterface = $"using Domain.Entites;\r\nnamespace Application.IService\n{{\n\tpublic interface I{modelName}Service : IBaseService<{modelName}>\n\t{{\n\t}}\n}}";
            string repositoryClass = $"using Application.IInfrastructure;\r\nusing Domain.Entites;\r\nusing Infrastructure.Context;\r\nusing Infrastructure.Repository.Base;\r\nnamespace Infrastructure.Repository\n{{\n\t public class {modelName}Repository : Repository<{modelName}>, I{modelName}Repository\n\t{{\n\t\t public {modelName}Repository(ApplicationDBContext context) : base(context)\n\t\t{{\n\t\t}}\n\t}}\n}}";
            string serviceClass = $"using Application.IInfrastructure;\r\nusing Application.IService;\r\nusing Domain.Entites;\r\nnamespace Application.Service\n{{\n\t public class {modelName}Service : BaseService<{modelName}>, I{modelName}Service\n\t{{\n\t\t public {modelName}Service(IRepository<{modelName}> repository) : base(repository)\n\t\t{{\n\t\t}}\n\t}}\n}}";

            System.IO.File.WriteAllText(Path.Combine(applicationPath, "IInfrastructure/I" + modelName + "Repository.cs"), repositoryInterface);
            System.IO.File.WriteAllText(Path.Combine(applicationPath, "IService/I" + modelName + "Service.cs"), serviceInterface);
            System.IO.File.WriteAllText(Path.Combine(infrastructurePath, "Repository/" + modelName + "Repository.cs"), repositoryClass);
            System.IO.File.WriteAllText(Path.Combine(applicationPath, "Service/" + modelName + "Service.cs"), serviceClass);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

// نمونه‌ای از فراخوانی تابع برای مدل User

