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

    // Products Above Average Price
    public class ProductsAboveAveragePriceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public ProductsAboveAveragePriceConfiguration()
            : this("dbo")
        {
        }

        public ProductsAboveAveragePriceConfiguration(string schema)
        {
            ToTable("Products Above Average Price", schema);
            HasKey(x => x.ProductName);

            Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType("money").IsOptional().HasPrecision(19,4);
        }
    }

}
// </auto-generated>