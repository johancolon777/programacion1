using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a mi lista de contactos del itla ");

        bool running = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (running)
        {
            Console.WriteLine(@"
1. Agregar Contacto
2. Ver Contactos
3. Buscar Contacto
4. Modificar Contacto
5. Eliminar Contacto
6. Salir");
            Console.Write("Digite el número de la opción deseada dentro de las opciones siquientes y no sea bruto: ");
            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 2:
                    ViewContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 3:
                    SearchContact(ids, names, lastnames, telephones, emails);
                    break;

                case 4:
                    ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 5:
                    DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("¡Gracias por usar la agenda personal! del itla");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo con algo que sea coherente. ");
                    break;
            }
        }
    }

    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.Write("Nombre: ");
        string name = Console.ReadLine();
        Console.Write("Apellido: ");
        string lastname = Console.ReadLine();
        Console.Write("Dirección: ");
        string address = Console.ReadLine();
        Console.Write("Teléfono: ");
        string phone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Edad: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        int id = ids.Count + 1;
        ids.Add(id);
        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        telephones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;

        Console.WriteLine("Contacto agregado DIKE correctamente.
");
    }

    static void ViewContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine($"
{"ID",-4} {"Nombre",-10} {"Apellido",-10} {"Teléfono",-12} {"Email",-20} {"Edad",-5} {"Mejor Amigo"}");
        Console.WriteLine(new string('-', 70));

        foreach (var id in ids)
        {
            string best = bestFriends[id] ? "Sí" : "No";
            Console.WriteLine($"{id,-4} {names[id],-10} {lastnames[id],-10} {telephones[id],-12} {emails[id],-20} {ages[id],-5} {best}");
        }
        Console.WriteLine();
    }

    static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> telephones, Dictionary<int, string> emails)
    {
        Console.Write("Ingrese el nombre o apellido a buscar: ");
        string search = Console.ReadLine().ToLower();
        bool found = false;

        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(search) || lastnames[id].ToLower().Contains(search))
            {
                Console.WriteLine($"ID: {id} | {names[id]} {lastnames[id]} | Tel: {telephones[id]} | Email: {emails[id]}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No se encontraron contactos con ese nombre o apellido asi que no sea tan creativo.
");
    }

    static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.Write("Ingrese el ID del contacto a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("El ID no existe.
");
            return;
        }

        Console.Write("Nuevo nombre (actual: " + names[id] + "): ");
        names[id] = Console.ReadLine();
        Console.Write("Nuevo apellido (actual: " + lastnames[id] + "): ");
        lastnames[id] = Console.ReadLine();
        Console.Write("Nueva dirección (actual: " + addresses[id] + "): ");
        addresses[id] = Console.ReadLine();
        Console.Write("Nuevo teléfono (actual: " + telephones[id] + "): ");
        telephones[id] = Console.ReadLine();
        Console.Write("Nuevo email (actual: " + emails[id] + "): ");
        emails[id] = Console.ReadLine();
        Console.Write("Nueva edad (actual: " + ages[id] + "): ");
        edades[id] = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;

        Console.WriteLine("Contacto modificado correctamente.
");
    }

    static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("El ID no existe.
");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado correctamente.
");
    }
}