# 16. ¿Qué mostrará el programa?

Analizar el siguiente código:

```csharp
public abstract class Animal
{
    public string Nombre { get; set; }

    public abstract string HacerSonido();
}

public class Perro : Animal
{
    public override string HacerSonido()
    {
        return "Guau";
    }
}

public class Gato : Animal
{
    public override string HacerSonido()
    {
        return "Miau";
    }
}
```

Y:

```csharp
List<Animal> animales = new List<Animal>();

animales.Add(new Perro { Nombre = "Toby" });
animales.Add(new Gato { Nombre = "Luna" });

foreach (Animal animal in animales)
{
    Console.WriteLine(
        animal.Nombre + ": " + animal.HacerSonido()
    );
}
```

Sin ejecutar el programa:

1. Indica que mostrará por pantalla
Sacará por pantalla las siguientes lineas:
    Toby: Guau
    Luna: Miau

2. Indicar el tipo de la variable animal
Es una variable de tipo Animal

3. Indicar el tipo real del objeto en cada iteración
En la primera iteración es un objeto Perro, en la segunda iteración es un objeto Gato

4. Explicar por qué se ejecutan implementaciones diferentes de HacerSonido()
Al heredar de una clase abstracta, cuando se implementa el método abstracto, este se sobreescribe con un override. De esta forma cada clase hija que herede de Animal puede mostrar información distinta con el mismo método.

---

# 17. ¿Compila o no compila?

Utilizando las clases `Animal`, `Perro` y `Gato`, analizar los siguientes casos.

### A

```csharp
Animal animal = new Animal();
```

### B

```csharp
Animal animal = new Perro();
```

### C

```csharp
Perro perro = new Perro();
Animal animal = perro;
```

### D

```csharp
Animal animal = new Perro();
Perro perro = animal;
```

### E

```csharp
List<Animal> animales = new List<Animal>();

animales.Add(new Perro());
animales.Add(new Gato());
```

### F

```csharp
Animal animal = new Gato();

Console.WriteLine(animal.HacerSonido());
```

Para cada caso indicar:

1. Si compila.
2. Si no compila, explicar el motivo.
3. Si compila, indicar el tipo de la variable y el tipo real del objeto.

#### Caso A
No compilará. Animal es una clase abstracta, solo se puede acceder a ella a través de sus clases hijas.

#### Caso B
Si compilará. El tipo de la variable es Animal. El tipo de objeto real es Perro.

#### Caso C
Si compilará. El tipo de la variable es Animal. El tipo de objeto real es Perro.

#### Caso D
No compilará. Esto se debe a que una variable Animal no se puede convertir a Perro sin castear implicitamente animal a la clase
Perro antes.

#### Caso E
Si compilará. La variable de la lista es de tipo Animal. El primer add añade un objeto de tipo Perro a la lista. El segundo add
añade un objeto de tipo Gato a la lista.

#### Caso F
Si compilará. El tipo de la variable es Animal. El tipo de objeto real es Gato.