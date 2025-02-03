using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo01_Personnage.Data;

namespace Exo01_Personnage.Models;
internal static class IHM
{

    public static void AfficherMenu()
    {
        Console.WriteLine("1 - Créer un personnage");
        Console.WriteLine("2 - Mettre à jour un personnage");
        Console.WriteLine("3 - Afficher tous les personnages");
        Console.WriteLine("4 - Taper un personnage");
        Console.WriteLine("5 - Afficher les personnages ayant des PVs (PV+Armure) supérieurs à la moyenne");
        Console.WriteLine("0 - Quitter");
        Console.WriteLine("-----------------------------------------------");
    }

    private static void CreerPersonnage()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Création d'un personnage-----");

        var personnage = new Personnage();
        
        Console.Write("Saisir le pseudo du personnage:");
        personnage.Pseudo = Console.ReadLine()!;

        Console.Write("Saisir les points de vie du personnage:");
        personnage.PointsDeVie = int.Parse(Console.ReadLine()!);

        Console.Write("Saisir les points d'armure du personnage:");
        personnage.Armure = int.Parse(Console.ReadLine()!);

        Console.Write("Saisir les points de dégats du personnage:");
        personnage.Degats = int.Parse(Console.ReadLine()!);

        Console.Write("Saisir la date de création du personnage:");
        personnage.DateCreation = DateTime.Parse(Console.ReadLine()!);
        

        context.Personnages.Add(personnage);
        context.SaveChanges();
        Console.WriteLine("-----------------------------------------------");
    }


    private static void MajPersonnage()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Mettre à jour un personnage-----");

        Console.WriteLine("Quel personnage souhaitez-vous modifier ?(Tapez l'Id) : ");
        int choixId = int.Parse(Console.ReadLine()!);
        var personnage = context.Personnages.FirstOrDefault(p => p.Id == choixId);

        Console.Write("Modifier le pseudo du personnage:");
        personnage.Pseudo = Console.ReadLine()!;

        Console.Write("Modifier les points de vie du personnage:");
        personnage.PointsDeVie = int.Parse(Console.ReadLine()!);

        Console.Write("Modifier les points d'armure du personnage:");
        personnage.Armure = int.Parse(Console.ReadLine()!);

        Console.Write("Modifier les points de dégats du personnage:");
        personnage.Degats = int.Parse(Console.ReadLine()!);

        context.SaveChanges();
        Console.WriteLine("-----------------------------------------------");
    }

    private static void AfficherPersonnages()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Afficher tous les personnages-----");
        context.Personnages.ToList().ForEach(p => Console.WriteLine(p.Pseudo, p.PointsDeVie, p.Armure, p.Degats));
        Console.WriteLine("-----------------------------------------------");
    }

    private static void TaperPersonnage()
    {
        Console.WriteLine("-----Taper un personnage-----");

    }

    private static void AfficherPersoPV()
    {
        using var context = new ApplicationDbContext();
        
        Console.WriteLine("-----Afficher les personnages ayant des PVs (PV+Armure) supérieurs à la moyenne-----");

        var moyennePvArmure = context.Personnages.Average(p=>p.PointsDeVie + p.Armure);
        context.Personnages.Where(p => p.PointsDeVie + p.Armure>moyennePvArmure).ToList().ForEach(p => Console.WriteLine($"{p.Pseudo} {p.PointsDeVie} {p.Armure}"));
    }

    public static void Start()
    {
        while (true)
        {
            AfficherMenu();
            Console.WriteLine("Saisir votre choix : ");
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    CreerPersonnage();
                    break;
                case "2":
                    MajPersonnage();
                    break;
                case "3":
                    AfficherPersonnages();
                    break;
                case "4":
                    TaperPersonnage();
                    break;
                case "5":
                    AfficherPersoPV();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie");
                    break;
            }
        }
    }
}