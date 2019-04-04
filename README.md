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
![UNIT TEST EXAMPLE](https://xvnliw.bl.files.1drv.com/y4m_f54RzXyv2EBX0QdFjrLdHSZhBrZ4zAfaTJTpGehr3732gyILfhDhairVqgZRRnpWyZ6zACbWwcLYw6IxmVujYDw_AwSWy8PGIry1f_P9P1nhyPsQ2ceOcolGPU2-qP3OYfBhPzovfyAU95oEweSsCErppRneRSFo1lsp0UMYDZ_h_9ujY9VmbBCxJEpsuiJXFiaFzhy9DS4p3aSVX7ofw?width=660&height=496&cropmode=none)

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
![Bad Practice](https://xvnqiw.bl.files.1drv.com/y4m8u9ZWwtFn7hSLNsrw-LGy5hm6OpOVaYY6E5ZukUPNMvhGdX81RFt930GKxEQeqNXaxvl0ttLPgsoFNqQtr5JXNOsPgcyoJgaU_G98mnU1wRXAAKm5tiD4QF8oupAstCVRXvfu0tOx4_RE9XqS-Tree15x4Ng7hmNaTxhlpfHv86qDwPC81mUYSKp1ds80xDQEe9AAqtucw_oC0ol_oG4rA?width=660&height=237&cropmode=none)
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
![Good Practice](https://w37dga.bl.files.1drv.com/y4mg9sZ2dCgXdm-NV8JEprMttfTjnFIxHf_L_SF_70UJLIBWiR6umNdI8aFFS9nXbhmGcPHyuq51GEW53eydZlB2y7TZsEOxgC-ix7mW-v2y9DMKgT03vqgFPyO2xlKO__lDC1JUIIcs0r4mSVceALMEIlS6hzTo6qi1l9V-5nHhfNSqqfdqzNBjOtZ2xKRMbVd64GJ5dmPYZ5_9_k13di4lQ?width=660&height=175&cropmode=none)
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

#### Pruebas de integración
- Verifican el correcto funcionamiento del conjunto de elementos que componen el producto
- Se realizan después de las pruebas unitarias
- Nos permiten detectar defectos en las interfaces y en la interacción entre los diferentes componentes integrados

##### Requisitos
- Automatizable
- Completas
- Independientes
- Profesionales
- Fáciles de mantener