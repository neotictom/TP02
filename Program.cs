using System.Collections.Generic;
namespace TP02_Neimerman_Sedam;
class Program
{
    static void Main(string[] args)
    {
        List<Persona> listaPersonas = new List<Persona>();
        int menu = 0;
        string espacio = Environment.NewLine;
        while(menu != 5){
           menu = IngresarInt($"Ingrese una opcion {espacio}1. Cargar nueva persona{espacio}2. Obtener estadisticas del censo{espacio}3. Buscar persona{espacio}4. Modificar mail de una persona{espacio}5. Salir");
           switch(menu){
            case 1:
                CargarPersona(ref listaPersonas);
                break;
            case 2:
                EstadisticasCenso(listaPersonas);
                break;
            case 3:
                BuscarPersona(listaPersonas);
                break;
            case 4:
                CambiarEmail(listaPersonas);
                break;
           }
           
        }
        
    }
    
    static string IngresarString(string mensaje){
        string d;
        Console.WriteLine(mensaje);
        return d = Console.ReadLine();
    }
    static int IngresarInt(string mensaje){
        int d;
        Console.WriteLine(mensaje);
        return d = int.Parse(Console.ReadLine());
    }
      static void CargarPersona(ref List<Persona> listaPersonas){
        int DNI = 0;
        string nom = "",ape = "",email = "";
        DateTime fechaNac = DateTime.Today;
        Persona datos = new Persona(DNI,nom,ape,fechaNac,email);
        DNI = IngresarInt("Ingrese el dni");
        nom = IngresarString("Ingrese el nombre");
        ape = IngresarString("Ingrese el apellido");
        Console.WriteLine("Ingrese su fecha de nacimiento");
        fechaNac = DateTime.Parse(Console.ReadLine());
        email = IngresarString("Ingrese su email");
        datos = new Persona(DNI,nom,ape,fechaNac,email);
        listaPersonas.Add(datos);
        Console.WriteLine($"Se ha creado la persona {datos.Nombre} {datos.Apellido} y se ha agregado a la lista");
    }
    static void EstadisticasCenso(List<Persona> listapersonas){
        string e = Environment.NewLine;
        if (listapersonas.Count == 0){
            Console.WriteLine("Aún no se igresaron personas.");
        }
        else{
          int cantpersonas = listapersonas.Count;   
          int habilitadosvotar = listapersonas.Count(p => p.PuedeVotar());
          double promedio = listapersonas.Average(p => p.ObtenerEdad());
          Console.WriteLine($"Cantidad de personas: {cantpersonas}");
          Console.WriteLine($"Cantidad de personas habilitadas a votar: {habilitadosvotar}");
          Console.WriteLine($"Promedio de edad: {promedio}");
        }
    }
    static void BuscarPersona(List<Persona> listapersonas){
        int dni = IngresarInt("Ingrese el dni que quiere buscar");
        bool v = false;
        string espacio = Environment.NewLine;
        foreach(Persona datos in listapersonas){
            if(dni == datos.DNI){
                string fechanac = datos.FechaNacimiento.ToShortDateString();
                Console.WriteLine($"Nombre: {datos.Nombre}{espacio}Apellido: {datos.Apellido}{espacio}Fecha de nacimiento: {fechanac}{espacio}Email: {datos.Email}");
            }
           
        }
        if(v = false)
        {
            Console.WriteLine("El DNI ingresado no es correcto, ingrese devuelta");
        }
        dni = 0;
        
    }
    static void CambiarEmail(List<Persona> listapersonas){
        int dni = IngresarInt("Ingrese el dni de la persona que este buscando");
        bool v = false;
        foreach(Persona p in listapersonas){
            if(dni == p.DNI){
                string nuevoCorreo = IngresarString($"Ingrese el nuevo correo de la persona {p.Nombre}");
                p.Email = nuevoCorreo;
                Console.WriteLine($"El correo de la persona {p.Nombre} ahora es {p.Email}");
                v = true;
            }
            
        }
        if(v = false)
        {
            Console.WriteLine("El DNI ingresado no es correcto, ingrese devuelta");
        }
        dni = 0;
    }
    
}    
