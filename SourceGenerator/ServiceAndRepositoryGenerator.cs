using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;


[Generator]
public class ServiceAndRepositoryGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // تنظیمات اولیه اگر نیاز باشد.
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // فیلتر کردن تمام کلاس‌های موجود در Namespace `Domain.Entities`
        var models = context.Compilation.SyntaxTrees
            .SelectMany(syntaxTree => syntaxTree.GetRoot()
                .DescendantNodes().OfType<ClassDeclarationSyntax>())
            .Where(classNode => classNode.Parent is NamespaceDeclarationSyntax namespaceNode &&
                                namespaceNode.Name.ToString() == "Domain.Entites");

        foreach (var model in models)
        {
            var modelName = model.Identifier.Text;

            // بررسی وجود اینترفیس ریپازیتوری
            var repositoryInterfaceName = $"I{modelName}Repository";
            var repositoryClassName = $"{modelName}Repository";
            var serviceInterfaceName = $"I{modelName}Service";
            var serviceClassName = $"{modelName}Service";

            if (!FileExists(context, repositoryInterfaceName))
            {
                var iRepositoryCode = GenerateIRepositoryCode(modelName);
                context.AddSource($"{repositoryInterfaceName}.cs", SourceText.From(iRepositoryCode, Encoding.UTF8));
            }

            if (!FileExists(context, repositoryClassName))
            {
                var repositoryCode = GenerateRepositoryCode(modelName);
                context.AddSource($"{repositoryClassName}.cs", SourceText.From(repositoryCode, Encoding.UTF8));
            }

            if (!FileExists(context, serviceInterfaceName))
            {
                var iServiceCode = GenerateIServiceCode(modelName);
                context.AddSource($"{serviceInterfaceName}.cs", SourceText.From(iServiceCode, Encoding.UTF8));
            }

            if (!FileExists(context, serviceClassName))
            {
                var serviceCode = GenerateServiceCode(modelName);
                context.AddSource($"{serviceClassName}.cs", SourceText.From(serviceCode, Encoding.UTF8));
            }
        }
    }

    // بررسی وجود فایل در پروژه
    private bool FileExists(GeneratorExecutionContext context, string fileName)
    {
        // جستجوی کدهای تولید شده
        return context.AdditionalFiles.Any(file => Path.GetFileNameWithoutExtension(file.Path) == fileName);
    }

    // تولید اینترفیس ریپازیتوری
    private string GenerateIRepositoryCode(string modelName)
    {
        return $@"
                namespace Application.IInfrastructure
                {{
                    public interface I{modelName}Repository
                    {{
                    }}
                }}";
    }

    // تولید کلاس ریپازیتوری
    private string GenerateRepositoryCode(string modelName)
    {
        return $@"
        using Domain.Entities;
        using Infrastructure.Data;

        namespace Infrastructure.Repository
        {{
            public class {modelName}Repository : Repository<{modelName}>, I{modelName}Repository
            {{
                public {modelName}Repository(ApplicationDBContext context) : base(context)
                {{
                }}
            }}
        }}";
    }

    // تولید اینترفیس سرویس
    private string GenerateIServiceCode(string modelName)
    {
        return $@"
        using Domain.Entities;

        namespace Application.IService
        {{
            public interface I{modelName}Service : IBaseService<{modelName}>
            {{
            }}
        }}";
    }

    // تولید کلاس سرویس
    private string GenerateServiceCode(string modelName)
    {
        return $@"
        using Domain.Entities;
        using Application.IInfrastructure;

        namespace Application.Service
        {{
            public class {modelName}Service : BaseService<{modelName}>, I{modelName}Service
            {{
                public {modelName}Service(IRepository<{modelName}> repository) : base(repository)
                {{
                }}
            }}
        }}";
    }
}
