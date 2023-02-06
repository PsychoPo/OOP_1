using System;

namespace Lab1 // 21. В исходном тексте удалить все строки, начинающиеся на заданную букву.
{
	class lab1
	{
		static void Main(string[] args)
		{
			Console.Write("\nЦель данной программы удаление всех строк, начинающихся на заданную пользователем букву.\n");
			int option = 0;
			while (option != 10)
			{
				Console.Write("\n1. Старт;\n10. ВЫХОД.\nВвод: ");
				option = Convert.ToInt32(Console.ReadLine()!);
				switch (option)
				{
					case 1:
						{
							string filename, newfilename, str;
							char ch;
							Console.Write("\nВведите название файла: ");
							filename = Console.ReadLine()!;
							Console.Write("Введите букву: ");
							str = Console.ReadLine()!;
							ch = Convert.ToChar(str.ToLower().Remove(1));
							Console.WriteLine();
							try
							{
								StreamReader fin = new StreamReader(filename);
								StreamWriter fout = new StreamWriter(newfilename = filename.Replace(".txt", "_new.txt"));
								string? s; //Для описания ссылочных типов, допускающих значение null, C# 8 заимствует синтаксис значимых типов и использует оператор ?
								long i = 0;
								while ((s = fin.ReadLine()) != null)
								{
									if (s.ToLower().StartsWith(ch) == true)
									{
										s.Remove(0);
									}
									else
									{
										fout.WriteLine(s);
										Console.WriteLine($"{++i}: {s}");
									}
								}
								fin.Close();
								fout.Close();
							}
							catch (FileNotFoundException e)
							{
								Console.WriteLine(e.Message);
								Console.WriteLine("Введите корректное название файла.\n");
								return;
							}
							Console.WriteLine();
							break;
						}
					case 10:
						{
							//exit
							break;
						}
					default:
						{
							Console.WriteLine("\nВведено неверное число.\nВведите число 1 или 10.");
							break;
						}
				}
			}
		}
	}
}
