using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact>();
        bool running = true;

        Console.WriteLine("----AGENDA PERSONAL PARA ITLA----");

        while (running)
        {
            MostrarMenu();

            int opcion;

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe escribir un número de los que estan en las opciones ");
                continue;
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    AgregarContacto(contacts);
                    break;

                case 2:
                    ListarContactos(contacts);
                    break;

                case 3:
                    Console.Write("Buscar contacto del ITLA: ");
                    string termino = Console.ReadLine();
                    BuscarContacto(contacts, termino);
                    break;

                case 4:
                    Console.Write("ID del contacto a modificar: ");
                    int idEdit = Convert.ToInt32(Console.ReadLine());
                    EditarContacto(contacts, idEdit);
                    break;

                case 5:
                    Console.Write("ID del contacto a eliminar: ");
                    int idDelete = Convert.ToInt32(Console.ReadLine());
                    EliminarContacto(contacts, idDelete);
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida no sea incoherente.");
                    break;
            }

            Console.WriteLine("
Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("1. Agregar Contacto de algun estudiante ");
        Console.WriteLine("2. Ver Contactos guardados");
        Console.WriteLine("3. Buscar Contacto");
        Console.WriteLine("4. Modificar Contacto");
        Console.WriteLine("5. Eliminar Contacto");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción de las siguientes: ");
    }

    static void AgregarContacto(List<Contact> contacts)
    {
        Console.WriteLine("Agregar nuevo contacto");

        int id = contacts.Count + 1;

        Contact c = new Contact();
        c.Id = id;

        Console.Write("Nombre: ");
        c.Name = Console.ReadLine();

        Console.Write("Apellido: ");
        c.LastName = Console.ReadLine();

        Console.Write("Email: ");
        c.Email = Console.ReadLine();

        Console.Write("Dirección: ");
        c.Address = Console.ReadLine();

        Console.Write("Edad: ");
        c.Age = Convert.ToInt32(Console.ReadLine());

        Console.Write("¿Es favorito? 1=Si, 2=No: ");
        int fav = Convert.ToInt32(Console.ReadLine());
        if (fav == 1)
        {
            c.SetAsFavorite();
        }

        contacts.Add(c);
        Console.WriteLine("Contacto agregado correctamente :) ");
    }

    static void ListarContactos(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        Console.WriteLine("Lista de contactos del itla :");
        Console.WriteLine("--------------------");

        foreach (var c in contacts)
        {
            string fav = c.IsFavorite ? "Sí" : "No";
            Console.WriteLine($"ID: {c.Id} | {c.FullName} | {c.Email} | Favorito: {fav}");
        }
    }

    static void BuscarContacto(List<Contact> contacts, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            Console.WriteLine("Debe escribir algo para buscar.");
            return;
        }

        searchTerm = searchTerm.ToLower();

        var encontrados = contacts
            .Where(c =>
                c.Name.ToLower().Contains(searchTerm) ||
                c.LastName.ToLower().Contains(searchTerm) ||
                c.Email.ToLower().Contains(searchTerm))
            .ToList();

        if (encontrados.Count == 0)
        {
            Console.WriteLine("No se encontraron coincidencias intente de nuevo .");
            return;
        }

        Console.WriteLine("Resultados encontrados:");
        Console.WriteLine("-----------------------");

        foreach (var c in encontrados)
        {
            Console.WriteLine($"ID: {c.Id} | {c.FullName} | {c.Email}");
        }
    }

    static void EditarContacto(List<Contact> contacts, int id)
    {
        var c = contacts.FirstOrDefault(x => x.Id == id);

        if (c == null)
        {
            Console.WriteLine("Ese contacto no existe ");
            return;
        }

        Console.WriteLine($"Editando a {c.FullName}");

        Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            c.Name = name;

        Console.Write("Nuevo apellido: ");
        string last = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(last))
            c.LastName = last;

        Console.Write("Nuevo email: ");
        string email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email))
            c.Email = email;

        Console.Write("Nueva dirección: ");
        string address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address))
            c.Address = address;

        Console.Write("Nueva edad: ");
        string ageStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(ageStr))
            c.Age = Convert.ToInt32(ageStr);

        Console.WriteLine("Contacto actualizado.");
    }

    static void EliminarContacto(List<Contact> contacts, int id)
    {
        var c = contacts.FirstOrDefault(x => x.Id == id);

        if (c == null)
        {
            Console.WriteLine("No existe ningún contacto con ese ID.");
            return;
        }

        Console.WriteLine($"¿Seguro que desea eliminar a {c.FullName}? (s/n)");
        string resp = Console.ReadLine().ToLower();

        if (resp == "s")
        {
            contacts.Remove(c);
            Console.WriteLine("Contacto eliminado por inutil.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
    }
}