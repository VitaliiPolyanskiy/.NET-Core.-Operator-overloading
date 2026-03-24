// Приклад перевантаження операторів

using System;
using System.Text;
// Клас тривимірних координат

class ThreeD
{
    int x, y, z; // 3-мірні координати.
    public ThreeD() { x = y = z = 0; }
    public ThreeD(int i, int j, int k)
    {
        x = i;
        y = j;
        z = k;
    }

    // Перевантаження бінарного оператора "+"
    public static ThreeD operator +(ThreeD op1, ThreeD op2)
    {
        ThreeD result = new()
        {
            x = op1.x + op2.x,
            y = op1.y + op2.y,
            z = op1.z + op2.z
        };
        return result;
    }

    // Перевантаження бінарного оператора "-"
    public static ThreeD operator -(ThreeD op1, ThreeD op2)
    {
        ThreeD result = new()
        {
            x = op1.x - op2.x,
            y = op1.y - op2.y,
            z = op1.z - op2.z
        };
        return result;
    }

    // Перевантаження унарного оператора "-"
    public static ThreeD operator -(ThreeD op)
    {
        ThreeD result = new()
        {
            x = -op.x,
            y = -op.y,
            z = -op.z
        };
        return result;
    }

    // Перевантаження унарного оператора "++"
    public static ThreeD operator ++(ThreeD op)
    {
        ThreeD result = new()
        {
            x = op.x + 1,
            y = op.y + 1,
            z = op.z + 1
        };
        return result;
    }
    // Перевантаження унарного оператора "--"
    public static ThreeD operator --(ThreeD op)
    {
        ThreeD result = new()
        {
            x = op.x - 1,
            y = op.y - 1,
            z = op.z - 1
        };
        return result;
    }

    // Перевантаження бінарного оператора "+" для сумування об'єкта та int-значення.
    public static ThreeD operator +(ThreeD opl, int op2)
    {
        ThreeD result = new()
        {
            x = opl.x + op2,
            y = opl.y + op2,
            z = opl.z + op2
        };
        return result;
    }

    // Перевантаження бінарного оператора "+" для варіанта int-значення + об'єкт.
    public static ThreeD operator +(int opl, ThreeD op2)
    {
        ThreeD result = new()
        {
            x = op2.x + opl,
            y = op2.y + opl,
            z = op2.z + opl
        };
        return result;
    }

    // Оператори відношень перевантажуються парами 1) < > 2)== != 3)>= <=
    // Перевантаження оператора "<".
    public static bool operator <(ThreeD op1, ThreeD op2)
    {
        if ((op1.x < op2.x) && (op1.y < op2.y) && (op1.z < op2.z))
            return true;
        else
            return false;
    }

    // Перевантаження оператора ">".
    public static bool operator >(ThreeD op1, ThreeD op2)
    {
        if ((op1.x > op2.x) && (op1.y > op2.y) && (op1.z > op2.z))
            return true;
        else
            return false;
    }

    // Перевантаження оператора "==".
    public static bool operator ==(ThreeD op1, ThreeD op2)
    {
        if ((op1.x == op2.x) && (op1.y == op2.y) && (op1.z == op2.z))
            return true;
        else
            return false;
    }

    // Перевантаження оператора "!=".
    public static bool operator !=(ThreeD op1, ThreeD op2)
    {
        if ((op1.x != op2.x) || (op1.y != op2.y) || (op1.z != op2.z))
            return true;
        else
            return false;
    }

    // Неявне перетворення з об'єкта класу на стандартний тип
    public static implicit operator int(ThreeD op1)
    {
        return op1.x * op1.y * op1.z;
    }


    // Неявне перетворення зі стандартного типу на об'єкт класу
    public static implicit operator ThreeD(int n)
    {
        ThreeD result = new(n, n, n);
        return result;
    }

    /*
     Всередині класу не може одночасно бути і explicit, і implicit перетворення.
     Якщо в класі є implicit, він спрацьовуватиме і при явному перетворенні.
     При explicit, твердження не є вірним.
     */

    // Явне перетворення
    //public static explicit operator int(ThreeD op1)
    //{
    //    return op1.x * op1.y * op1.z;
    //}

    // Відображаємо координати X, Y, Z.
    public void Show()
    {
        Console.WriteLine(x + ", " + y + ", " + z);
    }

    // Не можна перевантажувати .  []  ()  new  is  as  sizeof  typeof  ?:  =
}

class ThreeDDemo
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        ThreeD a = new(1, 2, 3);
        ThreeD b = new(10, 10, 10);
        ThreeD c = new();
        Console.Write("Координати точки а: ");
        a.Show();
        int w = c;
        Console.WriteLine();
        Console.Write("Координати точки b: ");
        b.Show();
        Console.WriteLine();
        a = --b;
        Console.Write("Результат інкрементування b++: ");
        a.Show();
        Console.WriteLine();
        b.Show();
        c = a + b;
        Console.Write("Результат додавання а + b: ");
        c.Show();
        Console.WriteLine();
        c = a + b + c;
        Console.Write("Результат додавання а + b + с: ");
        c.Show();
        Console.WriteLine();
        c = c - a;
        Console.Write("Результат віднімання с - а: ");
        c.Show();
        Console.WriteLine();
        c = c - b;
        Console.Write("Результат віднімання с - Ь: ");
        c.Show();
        Console.WriteLine();
        c = -a;
        Console.Write("Результат присвоєння -а: ");
        c.Show();
        Console.WriteLine();
        b = a + 10;
        Console.Write("Результат додавання a + 10: ");
        b.Show();
        b = 10 + b;
        Console.Write("Результат додавання 10 + b: ");
        b.Show();
        if (a > c) Console.WriteLine("a > с - Істина");
        if (a < c) Console.WriteLine("a < с - Істина");
        if (a > b) Console.WriteLine("a > b - Істина");
        if (a < b) Console.WriteLine("a < b - Істина");
        a = c;
        if (a == c) Console.WriteLine("a == с - Істина");
        if (a != b) Console.WriteLine("a != b - Істина");
        int i;
        ThreeD d = new(1, 2, 3);
        i = d;
        Console.WriteLine("Результат присвоєння i = d: " + i);
        Console.WriteLine();
        i = d * 2;
        Console.WriteLine("Результат обчислення виразу d * 2: " + i);
        i = d;
        Console.WriteLine("Результат присвоєння i = d: " + i);
        Console.WriteLine();
        i = (int)d * 2;
        Console.WriteLine("Результат обчислення виразу d * 2: " + i);
        d = 100;
        Console.WriteLine("Результат неявного перетворення int в ThreeD");
        d.Show();
    }
}

