using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
<<<<<<< HEAD
        public DbSet<FraudReport> FraudReports { get; set; }
=======
        public DbSet<Fraud> Frauds { get; set; }
    }

    public class Fraud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImpostorDetails { get; set; } = string.Empty;

        [Required]
        public string ContactInfo { get; set; } = string.Empty;

        public string? Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
>>>>>>> 786e1f862257c28bd0a32b65a69c11fd44345073
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }
    }

    public class Library
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }

    public class FraudReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImpostorDetails { get; set; } = string.Empty;

        [Required]
        public string ContactInfo { get; set; } = string.Empty;

        public string Comments { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
