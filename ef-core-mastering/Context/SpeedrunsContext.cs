using ef_core_mastering.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_core_mastering.Context;

public partial class SpeedrunsContext : DbContext
{
    public SpeedrunsContext()
    {
    }

    public SpeedrunsContext(DbContextOptions<SpeedrunsContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=ep-winter-paper-74498429.us-east-2.aws.neon.tech;Database=ef-core-action_prac;Username=Hahhhayam;Password=ag1tKlbBTAP5;");
    }

    public virtual DbSet<Approve> Approves { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactsUser> ContactsUsers { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamesPlatform> GamesPlatforms { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguagesUser> LanguagesUsers { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Run> Runs { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("approves_pkey");

            entity.ToTable("approves");

            entity.HasIndex(e => new { e.RunId, e.AdminId }, "approves_run_id_admin_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RunId).HasColumnName("run_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.Approves)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_admins_approves");

            entity.HasOne(d => d.Role).WithMany(p => p.Approves)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles_approves");

            entity.HasOne(d => d.Run).WithMany(p => p.Approves)
                .HasForeignKey(d => d.RunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_runs_approves");

            entity.HasOne(d => d.Status).WithMany(p => p.Approves)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_statses_approves");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Name, "categories_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_pkey");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.Value, "contact_value_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('contact_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<ContactsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacts_users_pkey");

            entity.ToTable("contacts_users");

            entity.HasIndex(e => e.UserId, "contacts_users_user_id_contact_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");

            entity.HasOne(d => d.Contact).WithMany(p => p.ContactsUsers)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contacts_contacts_users");

            entity.HasOne(d => d.User).WithOne(p => p.ContactsUser)
                .HasForeignKey<ContactsUser>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_contacts_users");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pkey");

            entity.ToTable("countries");

            entity.HasIndex(e => e.Name, "country_name_flag_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('country_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Flag)
                .HasColumnName("flag");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("games_pkey");

            entity.ToTable("games");

            entity.HasIndex(e => e.Name, "games_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<GamesPlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("games_platforms_pkey");

            entity.ToTable("games_platforms");

            entity.HasIndex(e => e.GameId, "games_platforms_game_id_platform_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");

            entity.HasOne(d => d.Game).WithOne(p => p.GamesPlatform)
                .HasForeignKey<GamesPlatform>(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_games_games_platforms");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamesPlatforms)
                .HasForeignKey(d => d.PlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_platforms_games_platforms");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_pkey");

            entity.ToTable("languages");

            entity.HasIndex(e => e.Value, "language_value_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('language_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<LanguagesUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("languages_users_pkey");

            entity.ToTable("languages_users");

            entity.HasIndex(e => e.UserId, "languages_users_user_id_language_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Language).WithMany(p => p.LanguagesUsers)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_languages_languages_users");

            entity.HasOne(d => d.User).WithOne(p => p.LanguagesUser)
                .HasForeignKey<LanguagesUser>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_languages_users");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("platforms_pkey");

            entity.ToTable("platforms");

            entity.HasIndex(e => e.Name, "platforms_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Value, "roles_value_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Run>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("runs_pkey");

            entity.ToTable("runs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.GamePlatformId).HasColumnName("game_platform_id");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.Uploaded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("uploaded");
            entity.Property(e => e.VideoUrl)
                .HasColumnType("character varying")
                .HasColumnName("video_url");

            entity.HasOne(d => d.Category).WithMany(p => p.Runs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categories_runs");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.Runs)
                .HasForeignKey(d => d.GamePlatformId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_games_platforms_runs");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("statuses");

            entity.HasIndex(e => e.Value, "status_value_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('status_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.HasIndex(e => new { e.RunId, e.SpeedrunnerId }, "teams_run_id_speedrunner_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RunId).HasColumnName("run_id");
            entity.Property(e => e.SpeedrunnerId).HasColumnName("speedrunner_id");

            entity.HasOne(d => d.Run).WithMany(p => p.Teams)
                .HasForeignKey(d => d.RunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_runs_teams");

            entity.HasOne(d => d.Speedrunner).WithMany(p => p.Teams)
                .HasForeignKey(d => d.SpeedrunnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_speedrunners_teams");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Nickname)
                .HasColumnType("character varying")
                .HasColumnName("nickname");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_coutries_users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
