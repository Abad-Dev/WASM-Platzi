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

## Products
La sección de Products es un CRUD que demuestra las habilidades adquiridas con BlazorWasm:

### Create 
En la sección de Products, hay un botón para agregar un nuevo Producto.
<p align="center">
    <img src="Images/btn-create.png">
</p>

Ese botón redirige a un formulario, hecho con el componente ***EditForm***:
<p align="center">
    <img src="Images/create-form.png">
</p>

El botón guardar invoca al servicio `ProductService`, el cual se encarga de hacer la petición y guardar el producto en la api, luego, con la clase `NavigationManager` se redirige a la sección de productos nuevamente.

[AddProduct.razor](Pages/AddProduct.razor)
```c#
    private async Task Save()
    {
        newProduct.Images = new string[1] { newProduct.Image };
        await productService.Add(newProduct);
        navigationManager.NavigateTo("/products");
    }
```

### Read


### Update
Cada Producto tiene un botón para editarlo:
<p align="center">
    <img src="Images/edit-btn.png">
</p>

Este botón redirige mediante un `NavLink` a una página para editar el producto, donde se le envía el id del producto mediante la url.

En esta página, utilicé los [***Life cycles***](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-8.0) para obtener el id del parametro de la URL:
<p align="center">
    <img src="Images/lifecycle1.png" >
</p>

El parámetro se recibe en la variable `productId`, y se inicializa en la función `SetParametersAsync`:

[EditProduct.razor](Pages/EditProduct.razor)
```c#
    private Product newProduct = new();

    [Parameter]
    public string productId { get;set; }
    private List<Category> categories = new List<Category>();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        if (parameters.TryGetValue<string>("productId", out var value))
        {
            if (value is not null)
            {
                productId = value;
            }   
        }

        await base.SetParametersAsync(parameters);
    }
```

Luego, en la función `OnInitializedAsync` se hace uso del servicio `ProductService` para extraer de la API el producto y sus atributos:

```c#
    protected override async Task OnInitializedAsync()
    {
        Product dbProduct = await productService.GetProductByIdAsync(productId);

        newProduct = dbProduct;
        newProduct.Image = dbProduct.Images[0];
        newProduct.CategoryId = dbProduct.Category.Id;
        categories = await categoryService.Get();
    }
```

### Delete
