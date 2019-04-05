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

    [Test]
    public void Peek_PeekAnItem_ShouldReturnLastItem()
    {
        var stack = _stack.Push("foo");
        stack = stack.Push("bar");
        Assert.That(stack.Peek(), Is.EqualTo("bar"));
    }

    [Test]
    public void Pop_PopOffLastItem_ShouldReturnAnStackWithoutThePoppedItem()
    {
        var stack = _stack.Push("foo");
        stack = stack.Pop();
        Assert.That(stack.Count, Is.Zero);
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