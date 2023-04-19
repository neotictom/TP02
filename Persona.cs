class Persona {
public int DNI{get; set;}
public string Nombre{get; set;}
public string Apellido {get; set;}
public DateTime FechaNacimiento{get; set;}
public string Email{get; set;}

public Persona(int dni, string nom,string ape,DateTime fnac, string email){
    DNI = dni;
    Nombre = nom;
    Apellido = ape;
    FechaNacimiento = fnac;
    Email = email;
}
public bool PuedeVotar(){
    int edad = ObtenerEdad();
    return (edad<=18);
}
public int ObtenerEdad(){
    DateTime hoy = DateTime.Today;
    int edad = hoy.Year - FechaNacimiento.Year;
    return edad;
}
}