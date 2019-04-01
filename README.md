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
- **Pruebas unitarias**
- **Pruebas de regresión**
- **Pruebas de integración**
- Pruebas de humo
- Pruebas de aceptación

#### Tipos de pruebas no funcionales
- Pruebas de compatibilidad
- Pruebas de rendimiento
- Pruebas de usabilidad
- Pruebas de seguridad

#### Pruebas unitarias
- Centradas en probar únicamente funcionalidades concretas del programa cómo métodos o funciones
- Nos aseguran que el código principal está funcionando como esperábamos
![UNIT TEST EXAMPLE](https://xvnliw.bl.files.1drv.com/y4m_f54RzXyv2EBX0QdFjrLdHSZhBrZ4zAfaTJTpGehr3732gyILfhDhairVqgZRRnpWyZ6zACbWwcLYw6IxmVujYDw_AwSWy8PGIry1f_P9P1nhyPsQ2ceOcolGPU2-qP3OYfBhPzovfyAU95oEweSsCErppRneRSFo1lsp0UMYDZ_h_9ujY9VmbBCxJEpsuiJXFiaFzhy9DS4p3aSVX7ofw?width=660&height=496&cropmode=none)

  ##### Requisitos
  - Automatizable
  - Repetibles
  - Completas
  - Independientes
  - Profesionales
  - Rápidas de crear

  ##### Ventajas
  - Fomentan la refactorización
  - Simplifican las pruebas de integración
  - Documentan el código
  - Nos permiten programar dependiendo de abstracciones y no de implementaciones
  - Los errores son mas fáciles de localizar

  ##### Frameworks
  Para .NET en general tenemos disponibles una gran variedad de Frameworks que nos ayudarán a poder crear proyectos de pruebas unitarias para nuestro producto, cómo:
  - MSTest
  - **NUnit**
  - xUnit

  ##### Herramientas de mocking
  En .NET tenemos disponibles un conjunto de frameworks para realizar mocks o fake objects, son los siguientes:
  - **NSubstitute**
  - Moq4
  - Rhino Mocks

#### Pruebas de integración
- Verifican el correcto funcionamiento del conjunto de elementos que componen el producto
- Se realizan después de las pruebas unitarias
- Nos permiten detectar defectos en las interfaces y en la interacción entre los diferentes componentes integrados