namespace Persistence.Data.Configurations
{
    public class OrderConfigurations
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(o => o.Subtotal)
                .HasColumnType("decimal(8,2)");

            builder.HasMany(o => o.Items)
                .WithOne();

            builder.OwnsOne(o => o.Address, o => o.WithOwner());
            
        }
    }
}
