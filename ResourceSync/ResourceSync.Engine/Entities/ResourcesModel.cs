using System.Data.Entity;

namespace ResourceSync.Engine.Entities
{
    public class ResourcesModel : DbContext
    {
        public ResourcesModel()
            : base("name=ResourcesContext")
        {
        }

        public virtual DbSet<TextResources__Environment> TextResources__Environment { get; set; }
        public virtual DbSet<TextResources__Language> TextResources__Language { get; set; }
        public virtual DbSet<TextResources__ResourceFile> TextResources__ResourceFile { get; set; }
        public virtual DbSet<TextResources__ResourceKey> TextResources__ResourceKey { get; set; }
        public virtual DbSet<TextResources__ResourceValue> TextResources__ResourceValue { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextResources__Environment>()
                .HasMany(e => e.TextResources__ResourceFile)
                .WithOptional(e => e.TextResources__Environment)
                .HasForeignKey(e => e.TextResourcesEnvironment_TextResourcesEnvironmentID);

            modelBuilder.Entity<TextResources__Environment>()
                .HasMany(e => e.TextResources__ResourceKey)
                .WithOptional(e => e.TextResources__Environment)
                .HasForeignKey(e => e.TextResourcesEnvironment_TextResourcesEnvironmentID);

            modelBuilder.Entity<TextResources__Language>()
                .HasMany(e => e.TextResources__ResourceValue)
                .WithOptional(e => e.TextResources__Language)
                .HasForeignKey(e => e.Language_LanguageID);

            modelBuilder.Entity<TextResources__ResourceFile>()
                .HasMany(e => e.TextResources__ResourceKey)
                .WithOptional(e => e.TextResources__ResourceFile)
                .HasForeignKey(e => e.ResourceFile_ID);

            modelBuilder.Entity<TextResources__ResourceKey>()
                .HasMany(e => e.TextResources__ResourceValue)
                .WithOptional(e => e.TextResources__ResourceKey)
                .HasForeignKey(e => e.ResourceKey_ID)
                .WillCascadeOnDelete();
        }
    }
}