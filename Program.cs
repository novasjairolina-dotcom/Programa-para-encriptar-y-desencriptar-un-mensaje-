using System;

class Program
{
    // Matriz de encriptación A
    static int[,] A = {
        { 1, -2, 2 },
        { -1, 1, 3 },
        { 1, -1, -4 }
    };

    // Matriz inversa A⁻¹
    static int[,] AInv = {
        { -1, -10, -8 },
        { -1, -6, -5 },
        { 0, -1, -1 }
    };

    // Tabla que relaciona cada letra con un código numerico: posición 0 = espacio
    static char[] letras = { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };


    static void Main()
    {
        int opcion;

        do
        {
            // Subproblema 1
            MostrarMenu();

            Console.Write("Seleccione una opción (1-4): ");

            // Leer la opción
            string entrada = Console.ReadLine();
            opcion = int.Parse(entrada);


            // Procesar la opción seleccionada
            if (opcion == 1)
            {
                // Subproblema 2
                string mensaje = LeerMensaje();

                // Subproblema 3
                int[] cod = ConvertirMensajeACodigo(mensaje);

                // Subproblema 4
                int[,] matriz = FormarMatrices(cod);

                // Subproblema 5
                int[,] criptograma = EncriptarMensaje(matriz);

                // Subproblema 6
                MostrarCriptograma(criptograma);
            }
            else if (opcion == 2)
            {
                // Subproblema 7
                int[,] criptograma = LeerCriptograma();

                // Subproblema 8
                int[,] matriz = FormarMatricesCodificadas(criptograma);

                // Subproblema 9
                int[] cod = DesencriptarMensaje(matriz);

                // Subproblema 10
                string mensajeOriginal = ConvertirCodigosAMensaje(cod);

                // Subproblema 11
                MostrarMensaje(mensajeOriginal);
            }
            else if (opcion == 3)
            {
                // Opción 3: Encriptar y desencriptar

                // Subproblema 2
                string mensaje = LeerMensaje();

                // Subproblema 3
                int[] cod = ConvertirMensajeACodigo(mensaje);

                // Subproblema 4
                int[,] matriz = FormarMatrices(cod);

                // Subproblema 5
                int[,] criptograma = EncriptarMensaje(matriz);

                // Subproblema 6
                MostrarCriptograma(criptograma);

                // Subproblema 8
                int[,] matrizCodificada =
                    FormarMatricesCodificadas(criptograma);

                // Subproblema 9
                int[] codDesencriptado =
                    DesencriptarMensaje(matrizCodificada);

                // Subproblema 10
                string mensajeRecuperado =
                    ConvertirCodigosAMensaje(codDesencriptado);

                // Subproblema 11
                MostrarMensaje(mensajeRecuperado);
            }
            else if (opcion == 4)
            {
                Console.WriteLine("Programa finalizado");
                Console.WriteLine("Presione ENTER para salir...");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }

            if (opcion != 4)
            {
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcion != 4);
    }
     // para encriptar, convertimos las letras del mensaje en numeros, lo organizamos en grupos de tres y lo multiplicamos por la matriz y obtener el criptograma 

    // Subproblema 1: MostrarMenu()
    static void MostrarMenu()
    {
        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine("   PROYECTO DE ENCRIPTACIÓN DE MENSAJES");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Encriptar un mensaje");
        Console.WriteLine("2. Desencriptar un mensaje");
        Console.WriteLine("3. Encriptar y luego desencriptar");
        Console.WriteLine("4. Salir");
    }


    // Subproblema 2: LeerMensaje()
    static string LeerMensaje()
    {
        Console.Write("Ingrese el mensaje a encriptar: ");

        string mensaje = Console.ReadLine().ToUpper();

        return mensaje;
    }


    // Subproblema 3: ConvertirMensajeACodigo()
    static int[] ConvertirMensajeACodigo(string mensaje)
    {
        int[] cod = new int[mensaje.Length];

        for (int i = 0; i < mensaje.Length; i++)
        {
            cod[i] = LetraACodigo(mensaje[i]);
        }

        return cod;
    }


    // Subproblema 4: FormarMatrices()
    static int[,] FormarMatrices(int[] cod)
    {
        // Calcular cuántos grupos de 3 necesitamos
        int total = cod.Length;
        int grupo = total / 3;

        if (total % 3 != 0)
        {
            grupo = grupo + 1;
        }

        // Crear arreglo con ceros al final
        int[] conCeros = new int[grupo * 3];

        for (int i = 0; i < total; i++)
        {
            conCeros[i] = cod[i];
        }

        // Crear matriz
        int[,] r = new int[grupo, 3];

        for (int g = 0; g < grupo; g++)
        {
            r[g, 0] = conCeros[g * 3];
            r[g, 1] = conCeros[g * 3 + 1];
            r[g, 2] = conCeros[g * 3 + 2];
        }

        return r;
    }


    // Subproblema 5: EncriptarMensaje()
    static int[,] EncriptarMensaje(int[,] matriz)
    {
        int grupo = matriz.GetLength(0);

        // Crear matriz de resultado
        int[,] r = new int[grupo, 3];

        // Encriptar cada grupo de 3
        for (int g = 0; g < grupo; g++)
        {
            // Formar el vector con los 3 códigos
            int[] vec = new int[3];

            vec[0] = matriz[g, 0];
            vec[1] = matriz[g, 1];
            vec[2] = matriz[g, 2];

            // Multiplicar por la matriz A
            int[] encriptado =
                MultiplicarVectorPorMatriz(vec, A);

            // Guardar en la matriz resultado
            r[g, 0] = encriptado[0];
            r[g, 1] = encriptado[1];
            r[g, 2] = encriptado[2];
        }

        return r;
    }


    // Subproblema 6: MostrarCriptograma()
    static void MostrarCriptograma(int[,] criptograma)
    {
        Console.WriteLine("CRIPTOGRAMA GENERADO:");

        MostrarMatriz(criptograma);
    }


    // Subproblema 7: LeerCriptograma()
    static int[,] LeerCriptograma()
    {
        Console.WriteLine("Ingrese el criptograma (números separados por espacios):");

        string lineaCriptograma = Console.ReadLine();

        // Separar los números por espacios
        string[] partes = lineaCriptograma.Split(' ');

        // Contar cuántos números hay
        int cantidadNumeros = 0;

        for (int i = 0; i < partes.Length; i++)
        {
            if (partes[i] != "")
            {
                cantidadNumeros++;
            }
        }

        // Calcular cuántos grupos de 3
        int grupo = cantidadNumeros / 3;

        // Crear la matriz
        int[,] r = new int[grupo, 3];

        // Llenar la matriz con los números
        int indice = 0;

        for (int i = 0; i < partes.Length; i++)
        {
            if (partes[i] != "")
            {
                int fila = indice / 3;
                int columna = indice % 3;

                r[fila, columna] =
                    int.Parse(partes[i]);

                indice++;
            }
        }

        return r;
    }


    // Subproblema 8: FormarMatricesCodificadas()
    static int[,] FormarMatricesCodificadas(int[,] cripto)
    {
        int grupo = cripto.GetLength(0);

        int[,] r = new int[grupo, 3];

        for (int i = 0; i < grupo; i++)
        {
            r[i, 0] = cripto[i, 0];
            r[i, 1] = cripto[i, 1];
            r[i, 2] = cripto[i, 2];
        }

        return r;
    }


    // Subproblema 9: DesencriptarMensaje()
    static int[] DesencriptarMensaje(int[,] cripto)
    {
        int grupos = cripto.GetLength(0);

        int[] cod = new int[grupos * 3];

        // Desencriptar cada grupo de 3
        for (int g = 0; g < grupos; g++)
        {
            // Formar el vector con los 3 números del criptograma
            int[] vec = new int[3];

            vec[0] = cripto[g, 0];
            vec[1] = cripto[g, 1];
            vec[2] = cripto[g, 2];

            // Multiplicar por la matriz inversa A⁻¹
            int[] desen =
                MultiplicarVectorPorMatriz(vec, AInv);

            // Guardar los códigos recuperados
            cod[g * 3] = desen[0];
            cod[g * 3 + 1] = desen[1];
            cod[g * 3 + 2] = desen[2];
        }

        return cod;
    }


    // Subproblema 10: ConvertirCodigosAMensaje()
    static string ConvertirCodigosAMensaje(int[] cod)
    {
        // Convertir códigos a letras
        string mensaje = "";

        for (int i = 0; i < cod.Length; i++)
        {
            char letra = CodigoALetra(cod[i]);

            // No agregar espacios al final
            if (letra != ' ' ||
                (i < cod.Length - 1 && cod[i + 1] != 0))
            {
                mensaje = mensaje + letra;
            }
        }

        // Eliminar espacios al final
        return mensaje.TrimEnd();
    }


    // Subproblema 11: MostrarMensaje()
    static void MostrarMensaje(string mensaje)
    {
        Console.WriteLine("MENSAJE RECUPERADO:");
        Console.WriteLine(mensaje);
    }


    // Convierte una letra a su código numérico
    static int LetraACodigo(char letra)
    {
        for (int i = 0; i < letras.Length; i++)
        {
            if (letras[i] == letra)
            {
                return i;
            }
        }

        return 0;
    }


    // Convierte un código numérico a su letra
    static char CodigoALetra(int cod)
    {
        if (cod >= 0 && cod < letras.Length)
        {
            return letras[cod];
        }

        return ' ';
    }


    // Multiplica un vector de 3 elementos por una matriz de 3x3
    static int[] MultiplicarVectorPorMatriz(int[] v, int[,] m)
    {
        int[] r = new int[3];

        r[0] =
            v[0] * m[0, 0] +
            v[1] * m[1, 0] +
            v[2] * m[2, 0];

        r[1] =
            v[0] * m[0, 1] +
            v[1] * m[1, 1] +
            v[2] * m[2, 1];

        r[2] =
            v[0] * m[0, 2] +
            v[1] * m[1, 2] +
            v[2] * m[2, 2];

        return r;
    }


    // Muestra una matriz en pantalla
    static void MostrarMatriz(int[,] m)
    {
        int filas = m.GetLength(0);

        Console.WriteLine();

        for (int i = 0; i < filas; i++)
        {
            Console.WriteLine(
                "  " +
                m[i, 0] + "\t" +
                m[i, 1] + "\t" +
                m[i, 2]
            );
        }

        Console.WriteLine();
    }
}