// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace CodeFirstWithDb_POCOGen
{

    // Category Sales for 1997
    public class CategorySalesFor1997Configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CategorySalesFor1997>
    {
        public CategorySalesFor1997Configuration()
            : this("dbo")
        {
        }

        public CategorySalesFor1997Configuration(string schema)
        {
            ToTable("Category Sales for 1997", schema);
            HasKey(x => x.CategoryName);

            Property(x => x.CategoryName).HasColumnName(@"CategoryName").HasColumnType("nvarchar").IsRequired().HasMaxLength(15).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CategorySales).HasColumnName(@"CategorySales").HasColumnType("money").IsOptional().HasPrecision(19,4);
        }
    }

}
// </auto-generated>
