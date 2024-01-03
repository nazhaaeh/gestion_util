using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;

public class DBcontexAppt : DbContext
{
    private readonly RetryPolicy _retryPolicy;

    public DBcontexAppt(DbContextOptions<DBcontexAppt> options, RetryPolicy retryPolicy) : base(options)
    {
        _retryPolicy = retryPolicy;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Rolle> Rolles { get; set; }
    public DbSet<UserRolle> UserRolles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Utilisez la politique pour gérer les erreurs de connexion à la base de données
        optionsBuilder.UseSqlServer("coxString", options =>
        {
            options.EnableRetryOnFailure(
                maxRetryCount: 3, // Nombre maximum de tentatives
                maxRetryDelay: TimeSpan.FromSeconds(5), // Délai maximal entre les tentatives
                errorNumbersToAdd: null // Liste facultative de codes d'erreur SQL spécifiques à considérer pour la répétition
            );
            
        });

        // Vous pouvez également ajouter votre propre logique de répétition en cas d'autres erreurs
        _retryPolicy.Execute(() =>
        {
          
        });
    }


}
