using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo02_Hotel.Models;

internal class Client
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Telephone { get; set; } = null!;

    public override string ToString()
    {
        return $"Id: {Id:D3}, Nom: {Nom}, Prenom: {Prenom}, Telephone: {Telephone}";
    }
}