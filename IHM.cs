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

        personnage.DateCreation = DateTime.Now();

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
        context.Personnages.ToList().ForEach(p => Console.WriteLine(p.ToString));
        Console.WriteLine("-----------------------------------------------");
    }

    private static void TaperPersonnage()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Taper un personnage-----");

        Console.WriteLine("Sélectionnez un 1er personnage (Tapez l'Id) : ");
        int choixId = int.Parse(Console.ReadLine()!);
        Personnage personnage1 = context.Personnages.FirstOrDefault(p => p.Id == choixId);

        Console.WriteLine("Sélectionnez un 2ème personnage (Tapez l'Id) : ");
        choixId = int.Parse(Console.ReadLine()!);
        Personnage personnage2 = context.Personnages.FirstOrDefault(p => p.Id == choixId);

        do
        {
            int degatsFinaux = personnage1.Degats - personnage2.Armure;
            personnage2.PointsDeVie = personnage2.PointsDeVie - degatsFinaux;

            degatsFinaux = personnage2.Degats - personnage1.Armure;
            personnage1.PointsDeVie = personnage1.PointsDeVie - degatsFinaux;
        }
        while (personnage1.PointsDeVie > 0 || personnage2.PointsDeVie > 0);

        if (personnage1.PointsDeVie<=0)
        {
            context.Personnages.Remove(personnage1);
            personnage2.NombrePersonneTues++;
        }
        else if (personnage2.PointsDeVie <= 0)
        {
            context.Personnages.Remove(personnage2);
            personnage1.NombrePersonneTues++;
        }
        else
        {
            context.Personnages.Remove(personnage1);  // Si les deux personnages meurent, ils s'entretuent et sont donc supprimés tous les deux
            context.Personnages.Remove(personnage2);
        }

        context.SaveChanges();
    }

    private static void AfficherPersoPV()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Afficher les personnages ayant des PVs (PV+Armure) supérieurs à la moyenne-----");

        var moyennePvArmure = context.Personnages.Average(p => p.PointsDeVie + p.Armure);
        context.Personnages.Where(p => p.PointsDeVie + p.Armure > moyennePvArmure).ToList().ForEach(p => Console.WriteLine($"{p.Pseudo} {p.PointsDeVie} {p.Armure}"));
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