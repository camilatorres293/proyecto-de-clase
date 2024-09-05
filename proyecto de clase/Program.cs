using System;
using System.Collections.Generic;

class SistemaVentas
{
    static void Main(string[] args)
    {
        bool seguirComprando = true;
        List<Producto> carrito = new List<Producto>();

        Console.WriteLine("---- Bienvenido al Sistema de Ventas sientase comodo de comprar" +
            "lo que guste ----");

        while (seguirComprando)
        {
            Console.WriteLine("\nCategorías de productos:");
            Console.WriteLine("1. Tecnología");
            Console.WriteLine("2. Ropa");
            Console.WriteLine("3. Alimentos");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una categoría: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                MostrarProductos("Tecnología", carrito);
            }
            else if (opcion == "2")
            {
                MostrarProductos("Ropa", carrito);
            }
            else if (opcion == "3")
            {
                MostrarProductos("Alimentos", carrito);
            }
            else if (opcion == "4")
            {
                seguirComprando = false;
            }
            else
            {
                Console.WriteLine(" Su opción no válida.");
            }
        }

        MostrarResumen(carrito);
    }

    static void MostrarProductos(string categoria, List<Producto> carrito)
    {
        List<Producto> productos = new List<Producto>();

        if (categoria == "Tecnología")
        {
            productos.Add(new Producto("Laptop", 9000));
            productos.Add(new Producto("Smartphone", 500));
            productos.Add(new Producto("Auriculares", 525));
        }
        else if (categoria == "Ropa")
        {
            productos.Add(new Producto("Camisa", 299));
            productos.Add(new Producto("Pantalón", 375));
            productos.Add(new Producto("Chaqueta", 510));
        }
        else if (categoria == "Alimentos")
        {
            productos.Add(new Producto("Leche", 30));
            productos.Add(new Producto("Pan", 20));
            productos.Add(new Producto("Huevos", 100));
        }

        Console.WriteLine($"\nProductos de {categoria}:");

        foreach (var producto in productos)
        {
            Console.WriteLine($"{producto.Nombre} - Precio: ${producto.Precio}");
            Console.Write($"¿Cuántos {producto.Nombre} desea agregar algo mas carrito?: ");
            string cantidadTexto = Console.ReadLine();
            double cantidad = ConvertirADouble(cantidadTexto);

            if (cantidad > 0 && cantidad <= 100)
            {
                producto.Cantidad = cantidad;
                carrito.Add(producto);
                Console.WriteLine($"{producto.Nombre} Se añadido al carrito.");
            }
            else
            {
                Console.WriteLine("Cantidad no válida.");
            }
        }
    }

    static void MostrarResumen(List<Producto> carrito)
    {
        Console.WriteLine("\n---- EL resumen de su compra es : ----");
        double total = 0;

        foreach (Producto producto in carrito)
        {
            double impuesto = producto.Nombre.Contains("Laptop") || producto.Nombre.Contains("Smartphone") ? 0.18 :
                              producto.Nombre.Contains("Camisa") || producto.Nombre.Contains("Pantalón") ? 0.12 : 0.07;
            double subtotal = producto.Precio * producto.Cantidad;
            double totalProducto = subtotal + (subtotal * impuesto);
            total += totalProducto;

            Console.WriteLine($"{producto.Nombre} x{producto.Cantidad} - Subtotal: ${subtotal:F2} + Impuesto: ${subtotal * impuesto:F2} = Total: ${totalProducto:F2}");
        }

        Console.WriteLine("nTotal a pagar: ${total:F2}");
        Console.WriteLine("Gracias por su compra.");
    }

    static double ConvertirADouble(string texto)
    {
        try
        {
            return double.Parse(texto);
        }
        catch
        {
            Console.WriteLine("Entrada no válida, se usará 0 por defecto.");
            return 0;
        }
    }
}

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public double Cantidad { get; set; }

    public Producto(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = 0;
    }
}