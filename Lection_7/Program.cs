// Собрать строку с числами от a до b, a ≤ b
string NumbersFor(int a, int b) // Цикл 
{
    string result = String.Empty;
    for (int i = a; i <= b; i++)
    {
        result += $"{i} ";
    }
    return result;
}
// Console.WriteLine(NumbersFor(1, 10));

string NumbersRec(int a, int b) // Рекурсия
{
    if (a <= b) return $"{a} " + NumbersRec(a + 1, b); // от 1 ... 10
    if (a <= b) return NumbersRec(a + 1, b) + $"{a} "; // если надо от 10 ... 1 (a >= b)
    else return String.Empty;
}
// Console.WriteLine(NumbersRec(1, 10));


// Сумма чисел от 1 до n
int SumFor(int n)
{
    int result = 0;
    for (int i = 1; i <= n; i++) result += i;
    return result;
}
//Console.WriteLine(SumFor(10));

int SumRec(int n)
{
    if (n == 0) return 0;
    else return n + SumRec(n - 1);
}
//Console.WriteLine(SumRec(10));


// Факториал числа
int FactorialFor(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++) result *= i;
    return result;
}
//Console.WriteLine(FactorialFor(10)); 

int FactorialRec(int n)
{
    if (n == 1) return 1;
    else return n * FactorialRec(n - 1);
}
//Console.WriteLine(FactorialRec(10));

// Вычислить а в степени n
int PowerFor(int a, int n)
{   int result = 1;
    for (int i = 1; i <= n; i++) result *= a;
    return result;
}
//Console.WriteLine(PowerFor(2, 10));

int PowerRec(int a, int n)
{   //return n == 0 ? 1 : PowerRec(a, n - 1) * a; - тоже самое, что в следующих двух строках
    if (n == 0) return 1;
    else return PowerRec(a, n - 1) * a;
}
//Console.WriteLine(PowerFor(2, 10));

int PowerRecMath(int a, int n)
{
    if (n == 0) return 1;
    else if (n % 2 == 0) return PowerRecMath(a * a, n / 2);
    else return PowerRecMath(a, n - 1) * a;
}
//Console.WriteLine(PowerRecMath(2, 10));

// Перебор слов

//В некотором машинном алфавите имеются четыре
//буквы «а», «и», «с» и «в». Покажите все слова,
//состоящие из T букв, которые можно построить из букв
//этого алфавита
char[] s = { 'а', 'и', 'с','в'}; // массив символов

int count = s.Length;

int n = 1;

for (int i = 0; i < count; i++)
{
   for (int j = 0; j < count; j++)
   {
       for (int k = 0; k < count; k++) //для слова из 3 букв
       {
           for (int l = 0; l < count; l++) //для слова из 4 букв
           {
               for (int m = 0; m < count; m++)
               {
                   //Console.WriteLine($"{n++,-5}{s[i]}{s[j]}{s[k]}{s[l]}{s[m]}"); //для слова из 5 букв
               }
           }
       }
   }
}

// Общее решение рекурсия
// int n = 1;
void FindWords(string alphabet, char[] word, int length = 0)
{
   if (length == word.Length)
   {
       Console.WriteLine($"{n++} {new String(word)}");  return;
   }
   for (int i = 0; i < alphabet.Length; i++)
   {
       word[length] = alphabet[i];
       FindWords(alphabet, word, length + 1);
   }
}

//FindWords("аисв", new char[4]); // для слова из четырех символов

        //Как посмотреть содержимое папки? Директории
        //string path = "\Users\AV4\Downloads\Знакомство с языками программирования (лекции)\Лекция 7";
        //DirectoryInfo di = new DirectoryInfo(path);
        //System.Console.WriteLine(di.CreationTime); // - вывод времени создания
        //FileInfo[] fi = di.Getfiles(); // соержимое папки
        //for (int i = 0; i < fi.Length; i++)
        //{
            //System.Console.WriteLine(fi[i].Name);
        //}

void CatalogInfo(string path, string indent = "")      // РАБОТАЕТ!!
{
   DirectoryInfo catalogs = new DirectoryInfo(path);

   foreach (var currentCatalog in catalogs.GetDirectories())
   {
       Console.WriteLine($"{indent}{currentCatalog.Name}");
       CatalogInfo(currentCatalog.FullName, indent + "  ");
   }

   foreach (var item in catalogs.GetFiles())
   {
       Console.WriteLine($"{indent}{item.Name}");
   }
}
string path = @"C:\Users\AV4\Downloads\Знакомство с языками программирования (лекции)\Семинар 1";
//CatalogInfo(path);

// Игра в пирамидки
void Towers(string with = "1", string on = "3", string some = "2", int count = 3)
// int count = 3 - количество блинов
{
   if (count > 1) Towers(with, some, on, count - 1);
   Console.WriteLine($"{with} >> {on}");
   if (count > 1) Towers(some, on, with, count - 1);
}
// Towers();

//Обход разных структур
//Решение некоторых задач
//((4 - 2) * (1 + 3)) / 10 - разложить в столбец
string emp = String.Empty;
string[] tree = { emp, "/", "*", "10", "-", "+", emp, emp, "4", "2", "1", "3" };
//                 0    1    2     3    4    5    6    7    8    9    10   11
void InOrderTraversal(int pos = 1)
{
   if (pos < tree.Length)
   {
       int left = 2 * pos;
       int right = 2 * pos + 1;
       if (left < tree.Length && !String.IsNullOrEmpty(tree[left])) InOrderTraversal(left);
       Console.WriteLine(tree[pos]);
       if (right < tree.Length && !String.IsNullOrEmpty(tree[right])) InOrderTraversal(right);
   }
}
// InOrderTraversal();


// Печать квадрата, раскрашивание квадрата крестиками
int[,] pic = new int[10, 10]; 
for (int i = 0; i < 10; i++)
{
   pic[0, i] = 1;
   pic[i, 0] = 1;
   pic[i, 9] = 1;
   pic[9, i] = 1;
}

PrintImage(pic);
FillImage(1, 1);
Console.WriteLine();
PrintImage(pic);

void PrintImage(int[,] image) // заполнение пробелами и +
{
    for (int i = 0; i < image.GetLength(0); i++) 
    {
        for (int j = 0; j < image.GetLength(1); j++) 
        {
            //Console.Write($"{matr[i, j]} ");
            if(image[i, j] == 0) Console.Write($" ");
            else Console.Write($"+");
        }
    Console.WriteLine();
    }
}

void FillImage(int row, int col) // раскрашивание замкнутой области 1 (+)
{
    if (pic[row, col] == 0) 
    {
        pic[row, col] = 1;
        FillImage(row - 1, col);
        FillImage(row, col - 1);
        FillImage(row + 1, col);
        FillImage(row, col + 1);
    }
}


