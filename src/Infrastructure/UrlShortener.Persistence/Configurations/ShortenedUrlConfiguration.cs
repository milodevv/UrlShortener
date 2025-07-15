using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Persistence.Configurations
{
    public class ShortenedUrlConfiguration : IEntityTypeConfiguration<ShortenedUrl>
    {
        public void Configure(EntityTypeBuilder<ShortenedUrl> builder)
        {
            builder.ToTable("ShortenedUrls");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseMySqlIdentityColumn().IsRequired();
            builder.Property(x => x.Created).IsRequired().HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.LastModified).IsRequired(false);
            builder.Property(x => x.LastModifiedBy).IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.LongUrl).IsRequired().HasMaxLength(2048);
            builder.Property(x => x.ShortUrl).IsRequired().HasMaxLength(2048);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(9);
            builder.HasIndex(x => x.Code).IsUnique().HasDatabaseName("IX_ShortenedUrls_Code");
        }
    }
}
