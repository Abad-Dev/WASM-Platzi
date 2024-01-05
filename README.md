# WASM-Platzi

### Link de la página: https://jm-delivery.com/

### Tecnologías Usadas:
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Blazor](https://img.shields.io/badge/blazor-%235C2D91.svg?style=for-the-badge&logo=blazor&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

### Curso:
Este curso certifica mi aprendizaje del [Curso de Aplicaciones Web con Blazor WebAssembly y .NET](https://platzi.com/cursos/blazor-webassembly/) de la plataforma de cursos Platzi.
<p align="center">
    <img src="https://static.platzi.com/media/achievements/piezas-aplicaciones-web-blazor-erbassembly-net_buenas-practicas-y-codigo-limpio-en-.png"/>
</p>


Se puede descargar y ver el certificado en el siguiente [link](Images/diploma-blazor-webassembly.pdf)


## ¿Como funciona esta página?
Esta página aprovecha todos los recursos aprendidos en el curso, como por ejemplo los ***Componentes Compartidos***:

<p align="center">
    <img src="Images/title1.png" style="margin: 5px">
    <img src="Images/title2.png" style="margin: 5px">
    <img src="Images/title3.png" style="margin: 5px">
</p>

</br>

Estos 3 componentes usan el Componente compartido [ModuleTitle](Shared/ModuleTitle.razor) en la carpeta Shared. <br>
Además usan un atributo `Color` el cual se inserta los estilos para colorear el `::before` del título.

### Counter
En la sección de Counter, usé los [***Life cycles***](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-8.0) para inicializar la cuenta de un contador.
<p align="center">
    <img src="Images/lifecycle1.png" >
</p>

https://jm-delivery.com/counter?CounterFromQuery=256

La cuenta se inicializa con el queryString `CounterFromQuery`, el cual recibe en el parámetro `CounterFromQuery` y se inicializa en la función `OnInitialized()`:

[Counter.razor](Pages/Counter.razor)
```c#
    private int currentCount = 0;

    [Parameter]
    [SupplyParameterFromQuery]
    public string CounterFromQuery { get;set; }

    protected override void OnInitialized()
    {
        currentCount = CounterFromQuery != null ? int.Parse(CounterFromQuery) : 0;
    }
```
