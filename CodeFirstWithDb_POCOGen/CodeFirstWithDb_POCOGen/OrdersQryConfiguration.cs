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

    // Orders Qry
    public class OrdersQryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OrdersQry>
    {
        public OrdersQryConfiguration()
            : this("dbo")
        {
        }

        public OrdersQryConfiguration(string schema)
        {
            ToTable("Orders Qry", schema);
            HasKey(x => new { x.OrderId, x.CompanyName });

            Property(x => x.OrderId).HasColumnName(@"OrderID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CustomerId).HasColumnName(@"CustomerID").HasColumnType("nchar").IsOptional().IsFixedLength().HasMaxLength(5);
            Property(x => x.EmployeeId).HasColumnName(@"EmployeeID").HasColumnType("int").IsOptional();
            Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsOptional();
            Property(x => x.RequiredDate).HasColumnName(@"RequiredDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShippedDate).HasColumnName(@"ShippedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ShipVia).HasColumnName(@"ShipVia").HasColumnType("int").IsOptional();
            Property(x => x.Freight).HasColumnName(@"Freight").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.ShipName).HasColumnName(@"ShipName").HasColumnType("nvarchar").IsOptional().HasMaxLength(40);
            Property(x => x.ShipAddress).HasColumnName(@"ShipAddress").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.ShipCity).HasColumnName(@"ShipCity").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipRegion).HasColumnName(@"ShipRegion").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.ShipPostalCode).HasColumnName(@"ShipPostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.ShipCountry).HasColumnName(@"ShipCountry").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.Region).HasColumnName(@"Region").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar").IsOptional().HasMaxLength(15);
        }
    }

}
// </auto-generated>
