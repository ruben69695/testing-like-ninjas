[![Build Status](https://travis-ci.com/ruben69695/testing-like-ninjas.svg?branch=master)](https://travis-ci.com/ruben69695/testing-like-ninjas) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=testing-like-ninjas&metric=alert_status)](https://sonarcloud.io/dashboard?id=testing-like-ninjas) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=testing-like-ninjas&metric=coverage)](https://sonarcloud.io/dashboard?id=testing-like-ninjas)

## Bienvenidos al seminario "Testing Like Ninjas"

Este seminario, esta orientado para el desarrollo de pruebas funcionales utilizando el lenguaje C# para la plataforma .NET Core de Microsoft, pero la teoría es común para cualquier otro lenguaje, como Python, Java, Javascript... y un largo etc.

### Objetivos

1. Aprender la importancia de las pruebas de software
2. Indagar en los diferentes tipos de pruebas
3. Conocer los Frameworks mas comunes para pruebas
4. El Mocking y la Inyección de Dependencia
5. Convertirte en un ninja haciendo pruebas unitarias

### Pruebas de Software
- Actividades que forman parte del proceso de desarrollo de software
- Aseguran que la aplicación funcione correctamente
- Proporcionan información sobre la calida del producto

### Tipos de pruebas
- Funcionales
   - Comprueban que el producto funcione acorde a los requisitos funcionales
   - Detectan posibles errores durante la fase de desarrollo
   - La gran mayoría son automatizadas
- No funcionales
  - Ayudan a conocer que riesgos puede correr el producto en un futuro
  - Nos permiten saber si el producto tiene un mal desempeño o un bajo rendimiento en entornos de producción

#### Tipos de pruebas funcionales
- Pruebas unitarias
- Pruebas de regresión
- Pruebas de integración

### Pruebas unitarias
- Centradas en probar únicamente funcionalidades concretas del programa cómo métodos o funciones
- Nos aseguran que el código principal está funcionando como esperábamos

![UNIT TEST EXAMPLE](https://i.ibb.co/6ybZfhb/logger-library-2222.png[)

#### Requisitos
- Automatizable
- Repetibles
- Completas
- Independientes
- Profesionales
- Rápidas de crear

#### Ventajas
- Fomentan la refactorización
- Simplifican las pruebas de integración
- Documentan el código
- Nos permiten programar dependiendo de abstracciones y no de implementaciones
- Los errores son mas fáciles de localizar

#### Frameworks
Para .NET en general tenemos disponibles una gran variedad de Frameworks que nos ayudarán a poder crear proyectos de pruebas unitarias para nuestro producto, cómo:
- MSTest
- **NUnit**
- xUnit

#### Ejemplo de pruebas con NUnit
```csharp
[Test]
public void LogError_CallMethod_ShouldSetLastErrorProperty()
{
    _loggerHelper.LogError("error2");
    
    Assert.That(_loggerHelper.LastError, Is.EqualTo("error2"));
}

[Test]
public void LogError_CallMethod_ShouldRaiseErrorLoggedEvent()
{
    bool eventRaised = false;

    _loggerHelper.ErrorLogged += (sender, guid) => eventRaised = true;
    _loggerHelper.LogError("error3");
    
    Assert.That(eventRaised, Is.True);            
}

[Test]
public void LogError_PassEmptyError_ShouldThrowArgumentNullException()
{
    Assert.That(() => _loggerHelper.LogError(string.Empty), 
        Throws.ArgumentNullException);
}
```

#### Mocking
Nos permite poder simular el funcionamiento de objetos complejos en la clase que estamos probando. 
Algunos ejemplos:
- Acceso a recursos
- Acceso a base de datos
- Acceso a red o Internet
- Lógica de negocio
- Interacción con el sistema

###### Bad Practice
La clase StorageData depende completamente de DbStorage (Una clase de acceso a base de datos), por lo tanto StorageData no se puede probar de forma unitaria.
![Bad Practice](https://i.ibb.co/wcNXMkJ/storage-library-unit-tests-bad-2222.png)

```csharp
public class StorageData
{
    private readonly DbStorage _storage;

    public StorageData()
    {
        _storage = new DbStorage();
    }
}

public class DbStorage
{
    public bool Save(object item) { /* Access to database */ return true; }
}   
```

###### Good Practice
Separando la interfaz de la implementación en la clase DbStorage, podremos simular su funcionamiento mediante mocking. Ahora StorageData es fácil de probar de forma unitaria ya que depende de una abstracción y no de una implementación. 
![Good Practice](https://i.ibb.co/Vpzht7m/storage-library-unit-tests-good-2222.png)
```csharp
public class StorageData
{
    private readonly IStorage _storage;
    public StorageData(IStorage storage)
    {
        _storage = storage;
    }
}

public interface IStorage
{
    bool Save(object item);
}

public class DbStorage : IStorage
{
    public bool Save(object item) { return true; }
}
```


#### Herramientas de mocking
En .NET tenemos disponibles un conjunto de frameworks para realizar mocks (Fake object implementations), son los siguientes:
- **NSubstitute**
- Moq4
- Rhino Mocks

### Inyección de dependencia
La inyección de dependencia es un patrón de diseño que nos permite poder inyectar una dependencia en aquellas clases que las necesiten. Hay distintas formas de inyección:
- Por constructor
- Por propiedad
- Por método

##### Ventajas de inyectar abstracciones
- Nuestro código estará menos acoplado
- Para las pruebas unitarias nos permitrá poder simular el funcionamiento de estos objetos, creando nuestras propias implementaciónes
- Seguiriamos el principio de inversión de la dependencia (SOLI**D**)

##### Ejemplo
```csharp
public class StorageData
{
    private readonly IStorage _storage;
    public StorageData(IStorage storage)
    {
        _storage = storage;
    }
}
```

### Pruebas de integración
- Verifican el correcto funcionamiento del conjunto de elementos que componen el producto
- Se realizan después de las pruebas unitarias
- Nos permiten detectar defectos en las interfaces y en la interacción entre los diferentes componentes integrados

#### Requisitos
- Automatizable
- Completas
- Independientes
- Profesionales
- Fáciles de mantener

### NUnit
- Framework open source para el desarrollo de pruebas unitarias
- Nos sirve también para pruebas de integración
- Fork del conocido framework JUnit de Java
- Diseñado para TDD (Test Driven Development)

#### Plataformas soportadas
- .NET Framework 2.0+
- .NET Standard 1.4+
- .NET Core

#### Recursos
- [Repositorio de GitHub](https://github.com/nunit/nunit)
- [Paquete Nuget](https://www.nuget.org/packages/NUnit)
- [Documentación](https://github.com/nunit/docs/wiki/NUnit-Documentation)

#### Código
```csharp
/* -- Atributo que marca la clase como colección de tests -- */
[TestFixture] 
public class MyStackTest
{
    private MyStack<string> _stack;
    
    /* -- Atributo que marca este método para que se ejecute siempre antes de cada tests  -- */
    [SetUp] 
    public void Setup()
    {
        _stack = new MyStack<string>();
    }

    /* Un simple tests */
    [Test]
    public void Push_PushAnItem_ReturnStackWithThePushedItem()
    {
        var stack = _stack.Push("foo");

        /* Verificación de los resultados del test, lo que identifica si el tests pasa o no */
        Assert.That(stack.Count, Is.EqualTo(1)); 
    }

    [Test]
    public void Push_PushAnItem_SourceStackIsImmutableDueOperation()
    {
        _stack.Push("foo");
        Assert.That(_stack.Count, Is.Zero);
    }
}
```
#### Resultado de ejecución
```
Iniciando la ejecución de pruebas, espere...

Total de pruebas: 27. Correctas: 27. Con error: 0. Omitidas: 0.
La serie de pruebas se ejecutó correctamente.
Tiempo de ejecución de las pruebas: 1,5129 Segundos
```

#### Creando el proyecto en .NET Core
Abrimos terminal e introducimos el siguiente comando para crear la solución
```bash
dotnet new sln 
```

Creamos un directorio al mismo nivel que la solución
```bash
/Users/rubenarrebola/Develop/tests
.
├── maximo
└── tests.sln
1 directory, 1 file
```

Nos situamos en el directorio "maximo" y creamos un proyecto de tipo librería
```bash
dotnet new classlib
```

El comando nos creará la siguiente estructura
```bash
.
├── Class1.cs
├── maximo.csproj
└── obj
    ├── maximo.csproj.nuget.cache
    ├── maximo.csproj.nuget.g.props
    ├── maximo.csproj.nuget.g.targets
    └── project.assets.json
1 directory, 6 files
```

Renombramos la clase Class1.cs a Maximo.cs y creamos una implementación que haga romper el programa en tiempo de ejecución
```csharp
using System;
using System.Collections.Generic;

namespace maximo
{
    public class Maximo
    {
        public Maximo()
        { }

        public int Max(IEnumerable<int> numbers)
        {
            throw new NotImplementedException("Ups...");
        }
    }
}
```

Volvemos al directorio dónde se encuentra la solución y agregamos el proyecto maximo.csproj a la solución
```bash 
dotnet sln add maximo/maximo.csproj
```

#### Creando el proyecto de pruebas unitarias
Primero de todo creamos el directorio maximo.tests. La estructura quedará de la siguiente forma
```bash
.
├── maximo
│   ├── Maximo.cs
│   ├── maximo.csproj
│   └── obj
│       ├── maximo.csproj.nuget.cache
│       ├── maximo.csproj.nuget.g.props
│       ├── maximo.csproj.nuget.g.targets
│       └── project.assets.json
├── maximo.tests
└── tests.sln
3 directories, 7 files
```

Hacemos del directorio maximo.tests nuestro directorio actual y creamos el nuevo proyecto de tests
```bash 
dotnet new nunit
```

El comando nos creara un proyecto de tests usando NUnit como librería de pruebas.
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="nunit" Version="3.11.0" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.11.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.9.0" />
  </ItemGroup>

</Project>
```
El proyecto de pruebas requiere de otros paquetes para poder correr las pruebas unitarias. "dotnet new" en el paso anterior nos añade SDK de test de Microsoft, el framework de pruebas NUnit y el NUnit test adapter. Ahora tenemos que añadir una referencia entre el proyecto de pruebas y el proyecto maximo, usando el comando "dotnet add reference":
```bash 
dotnet add reference ..maximo/maximo.csproj
```

La estructura de la solución queda de la siguiente forma:
```bash
.
├── maximo
│   ├── Maximo.cs
│   ├── maximo.csproj
│   └── obj
│       ├── maximo.csproj.nuget.cache
│       ├── maximo.csproj.nuget.g.props
│       ├── maximo.csproj.nuget.g.targets
│       └── project.assets.json
├── maximo.tests
│   ├── UnitTest1.cs
│   ├── maximo.tests.csproj
│   └── obj
│       ├── maximo.tests.csproj.nuget.cache
│       ├── maximo.tests.csproj.nuget.g.props
│       ├── maximo.tests.csproj.nuget.g.targets
│       └── project.assets.json
└── tests.sln
4 directories, 13 files
```

Ahora agreguemos a la solución el proyecto de pruebas unitarias que acabamos de crear volviendo al directorio dónde se encuentra la solución
```bash 
dotnet sln add maximo.test/maximo.csproj
```

#### Creando nuestro primer test
Vayamos a realizar nuestra primera prueba unitaria, para ello vayamos a nuestro proyecto de tests y cambiemos el nombre de la clase UnitTest1 a MaximoTests.
Ahora escribamos nuestra clase de tests para testar la clase Maximo. Mas adelante explicaremos cada cosa con mas detalle:
```csharp
using System.Collections.Generic;
using NUnit.Framework;
using maximo;
namespace Tests
{
    [TestFixture]
    public class MaximoTests
    {
        private Maximo _max;

        [SetUp]
        public void Setup()
        {
            _max = new Maximo();
        }

        [Test]
        public void Max_PassList_ShouldReturnTheGreatestNumber()
        {
            var list = new List<int>() { 1, 2, 6, 98, 387, 4, 378, 39, 9, 1000, 23 };

            int maxNumber = _max.Max(list);

            Assert.That(maxNumber, Is.EqualTo(1000));
        }
    }
}
```
Una vez guardado vayamos a ejecutar las pruebas para ello utilizaremos el comando **dotnet test** que nos compilara todos los proyectos de la solución y además arrancara las pruebas buscando aquellos proyectos que sean de pruebas y ejecutará las pruebas.
```bash
dotnet test
````

Como podemos observar los test fallan, esto es debido a que no tenemos implementación en la clase Maximo. Hagamos que los tests pasen aplicando la correcta implementación en el método Max:
```csharp
public int Max(IEnumerable<int> numbers)
{
    int max = int.MinValue;
    foreach (int currentNum in numbers)
    {
        if(currentNum > max)
            max = currentNum;
    }
    return max;
}
```

Volvamos a pasar las pruebas:
```bash
dotnet test
```

Ahora cómo véis las pruebas ya pasan correctamente:
```bash
Iniciando la ejecución de pruebas, espere...

Total de pruebas: 1. Correctas: 1. Con error: 0. Omitidas: 0.
La serie de pruebas se ejecutó correctamente.
Tiempo de ejecución de las pruebas: 1,2999 Segundos
```

Vamos a explicar un poco los atributos de NUnit usados en los ejemplos y otros también se suelen usar:

| Atributo        | Tipo | Descripción
| --------------- | ---- | -------------
| TestFixture     | Clase  | Indica que la clase contiene pruebas unitarias 
| SetUp           | Método | Ejecuta ese método justo antes de la realización de cada uno de los métodos de pruebas
| Test            | Método | Nos indica que el método es un método de prueba
| OneTimeSetUp    | Método | Ejecuta el método una única vez antes de iniciar las pruebas del espacio de nombres
| OneTimeTearDown | Método | Ejecuta un método una única vez al acabar las pruebas del espacio de nombres
| SetUpFixture    | Clase  | Marca la clase que contiene los métodos OneTimeSetUp o OneTimeTearDown para todas las pruebas del espacio de nombres

Obviamente hay muchos mas atributos e información, para ello [visita la documentación de NUnit](https://github.com/nunit/docs/wiki/Attributes) sobre todos los atributos.
