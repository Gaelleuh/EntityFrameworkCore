using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exo02_Hotel.Data;

namespace Exo02_Hotel.Models;

internal class IHM
{
    public static void AfficherMenu()
    {
        Console.WriteLine("=====MENU PRINCIPAL=====");
        Console.WriteLine("1 - Ajouter un client");
        Console.WriteLine("2 - Afficher la liste des clients");
        Console.WriteLine("3 - Afficher les réservations d'un client");
        Console.WriteLine("4 - Ajouter une réservation");
        Console.WriteLine("5 - Annuler une réservation");
        Console.WriteLine("6 - Afficher la liste des réservations");
        Console.WriteLine("0 - Quitter");
        Console.WriteLine("-----------------------------------------------");
    }

    private static void AjouterClient()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Ajout d'un client-----");

        var client = new Client();

        Console.Write("Saisir le nom du client:");
        client.Nom = Console.ReadLine()!;

        Console.Write("Saisir le prénom du client:");
        client.Prenom = Console.ReadLine()!;

        Console.Write("Saisir le numéro de téléphone du client:");
        client.Telephone = Console.ReadLine()!;

        context.Clients.Add(client);
        context.SaveChanges();
        Console.WriteLine("Client ajouté avec succès !");
        Console.WriteLine("-----------------------------------------------");
    }

    private static void AfficherClients()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Afficher tous les clients-----");
        context.Clients.ToList().ForEach(c => Console.WriteLine(c.ToString()));
        Console.WriteLine("-----------------------------------------------");
    }

    private static void AfficherReservationsClient()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Afficher les réservations d'un client-----");

        Console.WriteLine("Pour sélectionner le client, tapez son nom : ");
        string? choixParNom = Console.ReadLine();
        Client client = context.Clients.First(c => c.Nom == choixParNom);
        Console.WriteLine($"Vous avez choisi de consulter la réservation de {client.Nom} {client.Prenom} : ");

        context.Reservations.ToList().ForEach(r => Console.WriteLine(r.ToString()));
       
    }

    private static void AjouterReservation()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Ajouter une réservation-----");
    }
    private static void AnnulerReservation()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Annuler une réservation-----");
    }

    private static void AfficherListeReservations()
    {
        using var context = new ApplicationDbContext();

        Console.WriteLine("-----Liste des réservations-----");
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
                    AjouterClient();
                    break;
                case "2":
                    AfficherClients();
                    break;
                case "3":
                    AfficherReservationsClient();
                    break;
                case "4":
                    AjouterReservation();
                    break;
                case "5":
                    AnnulerReservation();
                    break;
                case "6":
                    AfficherListeReservations();
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

